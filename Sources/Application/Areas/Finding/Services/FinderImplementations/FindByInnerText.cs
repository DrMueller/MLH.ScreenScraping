using System;
using Mmu.Mlh.ScreenScraping.Areas.WebElements.Models;

namespace Mmu.Mlh.ScreenScraping.Areas.Finding.Services.FinderImplementations
{
    internal class FindByInnerText : FinderBase
    {
        private string _upperText;

        protected override Func<WebElement, bool> FinderPredicate => f => f.InnerText.ToUpperInvariant() == _upperText;

        internal void Initialize(string innerText)
        {
            _upperText = innerText.ToUpperInvariant();
        }
    }
}