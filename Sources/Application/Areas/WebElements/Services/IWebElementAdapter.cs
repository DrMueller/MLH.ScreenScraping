using Mmu.Mlh.ScreenScraping.Areas.WebElements.Models;

namespace Mmu.Mlh.ScreenScraping.Areas.WebElements.Services
{
    public interface IWebElementAdapter
    {
        T Adapt<T>(WebElement element)
            where T : WebElement;
    }
}