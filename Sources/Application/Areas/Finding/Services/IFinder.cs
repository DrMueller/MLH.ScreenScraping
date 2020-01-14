using System.Collections.Generic;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;
using Mmu.Mlh.ScreenScraping.Areas.WebElements.Models;

namespace Mmu.Mlh.ScreenScraping.Areas.Finding.Services
{
    public interface IFinder
    {
        Maybe<WebElement> Find(IReadOnlyCollection<WebElement> elements);

        IReadOnlyCollection<WebElement> FindAll(IReadOnlyCollection<WebElement> elements);
    }
}