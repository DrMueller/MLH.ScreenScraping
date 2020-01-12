using System;
using System.Collections.Generic;
using System.Text;
using StructureMap;

namespace Mmu.Mlh.ScreenScraping.TestUI.Infrastructure.DependencyInjection
{
    public class TestUIRegistry : Registry
    {
        public TestUIRegistry()
        {
            Scan(scanner =>
            {
                scanner.AssemblyContainingType<TestUIRegistry>();
                scanner.WithDefaultConventions();
            });
        }

    }
}
