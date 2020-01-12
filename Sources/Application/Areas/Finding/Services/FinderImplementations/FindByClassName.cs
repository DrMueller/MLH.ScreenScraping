using System.Collections.Generic;
using System.Linq;
using Mmu.Mlh.ScreenScraping.Areas.WebElements.Models;

namespace Mmu.Mlh.ScreenScraping.Areas.Finding.Services.FinderImplementations
{
    internal class FindByClassName : IFinder
    {
        private string _className;

        public WebElement Find(IReadOnlyCollection<WebElement> elements)
        {
            return elements.SingleOrDefault(f => f.ClassName == _className);
        }

        internal void Initialize(string className)
        {
            _className = className;
        }
    }
}