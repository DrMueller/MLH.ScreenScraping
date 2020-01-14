using System.Collections.Generic;
using Mmu.Mlh.ScreenScraping.Areas.WebElements.Models;

namespace Mmu.Mlh.ScreenScraping.Areas.Native.Services
{
    internal interface IWebElementFetcher
    {
        IReadOnlyCollection<WebElement> Fetch(object nativeObject);
    }
}