using System.Globalization;
using System.Reflection;
using System.Windows.Controls;
using Mmu.Mlh.ScreenScraping.Areas.Browsers.Models;
using Mmu.Mlh.ScreenScraping.Areas.Browsers.Models.Implementation;
using Mmu.Mlh.ServiceProvisioning.Areas.Provisioning.Services;

namespace Mmu.Mlh.ScreenScraping.Areas.Browsers.Services.Implementation
{
    internal class BrowserFactory : IBrowserFactory
    {
        private readonly IServiceLocator _serviceLocator;

        public BrowserFactory(IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }

        public IBrowser Create(WebBrowser webBrowser)
        {
            HideScriptErrors(webBrowser);

            var browser = _serviceLocator.GetService<Browser>();
            browser.Initialize(webBrowser);

            return browser;
        }

        private static void HideScriptErrors(WebBrowser webBrowser)
        {
            var webBrowserField = typeof(WebBrowser).GetField("_axIWebBrowser2", BindingFlags.Instance | BindingFlags.NonPublic);
            if (webBrowserField == null)
            {
                return;
            }

            var objComWebBrowser = webBrowserField.GetValue(webBrowser);
            if (objComWebBrowser == null)
            {
                webBrowser.Loaded += (o, s) => HideScriptErrors(webBrowser); //// In case we are to early
                return;
            }

            objComWebBrowser.GetType().InvokeMember(
                "Silent",
                BindingFlags.SetProperty,
                null,
                objComWebBrowser,
                new object[] { true },
                CultureInfo.InvariantCulture);
        }
    }
}