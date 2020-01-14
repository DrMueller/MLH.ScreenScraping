using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Mlh.ScreenScraping.Areas.Finding.Services;
using Mmu.Mlh.ScreenScraping.Areas.WebElements.Models;

namespace Mmu.Mlh.ScreenScraping.Areas.Browsers.Models
{
    public interface IBrowser
    {
        T Find<T>(Func<IFinderFactory, IFinder> finderFactory)
            where T : WebElement;

        IReadOnlyCollection<WebElement> FindAll(Func<IFinderFactory, IFinder> finderFactory);

        Task Navigate(string source);

        Task WaitForPageToLoad(string pagePart);
    }
}