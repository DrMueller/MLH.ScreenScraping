using Mmu.Mlh.ScreenScraping.Areas.Finding.Services.FinderImplementations;
using Mmu.Mlh.ServiceProvisioning.Areas.Provisioning.Services;

namespace Mmu.Mlh.ScreenScraping.Areas.Finding.Services.Implementation
{
    internal class FinderFactory : IFinderFactory
    {
        private readonly IServiceLocator _serviceLocator;

        public FinderFactory(IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }

        public IFinder ByClassName(string className)
        {
            var finder = _serviceLocator.GetService<FindByClassName>();
            finder.Initialize(className);
            return finder;
        }

        public IFinder ById(string id)
        {
            var finder = _serviceLocator.GetService<FindById>();
            finder.Initialize(id);
            return finder;
        }

        public IFinder ByInnerText(string text)
        {
            var finder = _serviceLocator.GetService<FindByInnerText>();
            finder.Initialize(text);
            return finder;
        }

        public IFinder ByTagName(string tagName)
        {
            var finder = _serviceLocator.GetService<FindByTag>();
            finder.Initialize(tagName);
            return finder;
        }
    }
}