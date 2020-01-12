using System;
using System.Threading.Tasks;
using Mmu.Mlh.ScreenScraping.Areas.Finding.Services;
using Mmu.Mlh.ScreenScraping.Areas.WebElements.Models;

namespace Mmu.Mlh.ScreenScraping.Areas.Browsers.Models
{
    public interface IBrowser
    {
        T Find<T>(Func<IFinderFactory, IFinder> finderFactory)
            where T : WebElement;

        Task Navigate(string source);
    }
}