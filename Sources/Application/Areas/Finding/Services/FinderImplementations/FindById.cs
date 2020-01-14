using System;
using Mmu.Mlh.ScreenScraping.Areas.WebElements.Models;

namespace Mmu.Mlh.ScreenScraping.Areas.Finding.Services.FinderImplementations
{
    internal class FindById : FinderBase
    {
        private string _id;

        protected override Func<WebElement, bool> FinderPredicate => f => f.Id == _id;

        internal void Initialize(string id)
        {
            _id = id;
        }
    }
}