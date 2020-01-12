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
    }
}