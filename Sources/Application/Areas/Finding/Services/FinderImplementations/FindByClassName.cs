using System;
using Mmu.Mlh.ScreenScraping.Areas.WebElements.Models;

namespace Mmu.Mlh.ScreenScraping.Areas.Finding.Services.FinderImplementations
{
    internal class FindByClassName : FinderBase
    {
        private string _upperClassName;

        protected override Func<WebElement, bool> FinderPredicate => f => f.ClassName.ToUpperInvariant() == _upperClassName;

        internal void Initialize(string className)
        {
            _upperClassName = className.ToUpperInvariant();
        }
    }
}