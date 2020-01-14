using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;
using Mmu.Mlh.ScreenScraping.Areas.Finding.Services;
using Mmu.Mlh.ScreenScraping.Areas.Native.Services;
using Mmu.Mlh.ScreenScraping.Areas.WebElements.Models;
using Mmu.Mlh.ScreenScraping.Areas.WebElements.Services;

namespace Mmu.Mlh.ScreenScraping.Areas.Browsers.Models.Implementation
{
    internal class Browser : IBrowser
    {
        private readonly IFinderFactory _finderFactory;
        private readonly List<TaskCompletionSource<Uri>> _loaderSources;
        private readonly List<Uri> _uriHistory;
        private readonly IWebElementAdapter _webElementAdapter;
        private readonly IWebElementFetcher _webElementFetcher;

        private IReadOnlyCollection<WebElement> _elements;
        private WebBrowser _webBrowser;

        public Browser(
            IFinderFactory finderFactory,
            IWebElementAdapter webElementAdapter,
            IWebElementFetcher webElementFetcher)
        {
            _finderFactory = finderFactory;
            _webElementAdapter = webElementAdapter;
            _webElementFetcher = webElementFetcher;
            _loaderSources = new List<TaskCompletionSource<Uri>>();
            _uriHistory = new List<Uri>();
        }

        public T Find<T>(Func<IFinderFactory, IFinder> finderFactory)
            where T : WebElement
        {
            var finder = finderFactory(_finderFactory);
            var foundElement = finder.Find(_elements);
            var result = _webElementAdapter.Adapt<T>(foundElement);
            return result;
        }

        public IReadOnlyCollection<WebElement> FindAll(Func<IFinderFactory, IFinder> finderFactory)
        {
            var finder = finderFactory(_finderFactory);
            var result = finder.FindAll(_elements);
            return result;
        }

        public Task Navigate(string source)
        {
            // String.Empty because we want this task to fire for sure
            var pageLoaderSource = WaitForPageToLoad(string.Empty);
            _webBrowser.Navigate(source);
            return pageLoaderSource;
        }

        public Task WaitForPageToLoad(string pagePart)
        {
            var alreadyLoaded = _uriHistory.Any(uri => uri.ToString().Contains(pagePart, StringComparison.OrdinalIgnoreCase));
            if (alreadyLoaded)
            {
                return Task.CompletedTask;
            }

            var pageLoaderSource = new TaskCompletionSource<Uri>(pagePart);
            _loaderSources.Add(pageLoaderSource);

            return pageLoaderSource.Task;
        }

        internal void Initialize(WebBrowser webBrowser)
        {
            _webBrowser = webBrowser;
            _webBrowser.LoadCompleted += WebBrowser_LoadCompleted;
        }

        private void WebBrowser_LoadCompleted(object sender, NavigationEventArgs e)
        {
            _uriHistory.Add(e.Uri);
            _elements = _webElementFetcher.Fetch(_webBrowser.Document);

            CheckAndFireMatchingUrls(e.Uri);
        }

        private void CheckAndFireMatchingUrls(Uri loadedUri)
        {
            var uriStr = loadedUri.ToString();
            var matchingSources = _loaderSources
                .Where(f => uriStr.Contains((string)f.Task.AsyncState, StringComparison.OrdinalIgnoreCase))
                .ToList();

            matchingSources.ForEach(
                source =>
                {
                    source.SetResult(loadedUri);
                    _loaderSources.Remove(source);
                });
        }
    }
}