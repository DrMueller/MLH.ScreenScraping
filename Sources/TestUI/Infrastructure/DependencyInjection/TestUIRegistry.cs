using StructureMap;

namespace Mmu.Mlh.ScreenScraping.TestUI.Infrastructure.DependencyInjection
{
    public class TestUiRegistry : Registry
    {
        public TestUiRegistry()
        {
            Scan(
                scanner =>
                {
                    scanner.AssemblyContainingType<TestUiRegistry>();
                    scanner.WithDefaultConventions();
                });
        }
    }
}