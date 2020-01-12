using System;
using System.Collections.Generic;
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
        private readonly IWebElementAdapter _webElementAdapter;
        private readonly IWebElementFetcher _webElementFetcher;

        private IReadOnlyCollection<WebElement> _currentElements;
        private TaskCompletionSource<object> _navigationSource;
        private WebBrowser _webBrowser;

        public Browser(
            IFinderFactory finderFactory,
            IWebElementAdapter webElementAdapter,
            IWebElementFetcher webElementFetcher)
        {
            _finderFactory = finderFactory;
            _webElementAdapter = webElementAdapter;
            _webElementFetcher = webElementFetcher;
        }

        public T Find<T>(Func<IFinderFactory, IFinder> finderFactory)
            where T : WebElement
        {
            var finder = finderFactory(_finderFactory);
            var foundElement = finder.Find(_currentElements);

            var result = _webElementAdapter.Adapt<T>(foundElement);
            return result;
        }

        public Task Navigate(string source)
        {
            _navigationSource = new TaskCompletionSource<object>();
            _webBrowser.Navigate(source);
            return _navigationSource.Task;
        }

        internal void Initialize(WebBrowser webBrowser)
        {
            _webBrowser = webBrowser;
            _webBrowser.Navigated += WebBrowser_Navigated;
        }

        private void WebBrowser_Navigated(object sender, NavigationEventArgs e)
        {
            _currentElements = _webElementFetcher.Fetch(_webBrowser.Document);
            _navigationSource.SetResult(null);
        }
    }
}