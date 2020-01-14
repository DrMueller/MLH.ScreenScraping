using System;
using Mmu.Mlh.ScreenScraping.Areas.WebElements.Models;

namespace Mmu.Mlh.ScreenScraping.Areas.Finding.Services.FinderImplementations
{
    internal class FindByTag : FinderBase
    {
        private string _upperTagName;

        protected override Func<WebElement, bool> FinderPredicate => f => f.TagName.ToUpperInvariant() == _upperTagName;

        internal void Initialize(string tagName)
        {
            _upperTagName = tagName.ToUpperInvariant();
        }
    }
}