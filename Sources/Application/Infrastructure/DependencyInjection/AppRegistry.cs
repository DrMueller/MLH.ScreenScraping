using Mmu.Mlh.ScreenScraping.Areas.Browsers.Models;
using Mmu.Mlh.ScreenScraping.Areas.Browsers.Models.Implementation;
using Mmu.Mlh.ScreenScraping.Areas.Browsers.Services;
using Mmu.Mlh.ScreenScraping.Areas.Browsers.Services.Implementation;
using Mmu.Mlh.ScreenScraping.Areas.Finding.Services;
using Mmu.Mlh.ScreenScraping.Areas.Finding.Services.Implementation;
using Mmu.Mlh.ScreenScraping.Areas.Native.Services;
using Mmu.Mlh.ScreenScraping.Areas.Native.Services.Implementation;
using Mmu.Mlh.ScreenScraping.Areas.WebElements.Services;
using Mmu.Mlh.ScreenScraping.Areas.WebElements.Services.Implementation;
using StructureMap;

namespace Mmu.Mlh.ScreenScraping.Infrastructure.DependencyInjection
{
    public class AppRegistry : Registry
    {
        public AppRegistry()
        {
            Scan(scanner =>
            {
                scanner.AssemblyContainingType<AppRegistry>();
                scanner.AddAllTypesOf<IFinder>();
            });

            For<IFinder>().Transient();
            For<Browser>().Transient();
            For<IBrowserFactory>().Use<BrowserFactory>().Singleton();
            For<IFinderFactory>().Use<FinderFactory>().Singleton();
            For<IWebElementFetcher>().Use<WebElementFetcher>().Singleton();
            For<IWebElementAdapter>().Use<WebElementAdapter>().Singleton();
        }
    }
}