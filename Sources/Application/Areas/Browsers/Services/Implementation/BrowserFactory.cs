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
            var browser = _serviceLocator.GetService<Browser>();
            browser.Initialize(webBrowser);

            return browser;
        }
    }
}