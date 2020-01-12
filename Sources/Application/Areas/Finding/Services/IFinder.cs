using System.Collections.Generic;
using Mmu.Mlh.ScreenScraping.Areas.WebElements.Models;

namespace Mmu.Mlh.ScreenScraping.Areas.Finding.Services
{
    public interface IFinder
    {
        WebElement Find(IReadOnlyCollection<WebElement> elements);
    }
}