using System;
using System.Collections.Generic;
using System.Linq;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;
using Mmu.Mlh.ScreenScraping.Areas.WebElements.Models;

namespace Mmu.Mlh.ScreenScraping.Areas.Finding.Services.FinderImplementations
{
    internal abstract class FinderBase : IFinder
    {
        protected abstract Func<WebElement, bool> FinderPredicate { get; }

        public Maybe<WebElement> Find(IReadOnlyCollection<WebElement> elements)
        {
            var foundElement = elements.SingleOrDefault(FinderPredicate);
            return Maybe.CreateFromNullable(foundElement);
        }

        public IReadOnlyCollection<WebElement> FindAll(IReadOnlyCollection<WebElement> elements)
        {
            var foundElements = elements.Where(FinderPredicate).ToList();
            return foundElements;
        }
    }
}