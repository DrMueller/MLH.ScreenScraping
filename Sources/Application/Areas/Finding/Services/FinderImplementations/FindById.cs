using System.Collections.Generic;
using System.Linq;
using Mmu.Mlh.ScreenScraping.Areas.WebElements.Models;

namespace Mmu.Mlh.ScreenScraping.Areas.Finding.Services.FinderImplementations
{
    internal class FindById : IFinder
    {
        private string _id;

        public WebElement Find(IReadOnlyCollection<WebElement> elements)
        {
            return elements.SingleOrDefault(f => f.Id == _id);
        }

        internal void Initialize(string id)
        {
            _id = id;
        }
    }
}