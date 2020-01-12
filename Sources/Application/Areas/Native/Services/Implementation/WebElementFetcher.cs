using System.Collections.Generic;
using System.Linq;
using Mmu.Mlh.ScreenScraping.Areas.WebElements.Models;
using mshtml;

namespace Mmu.Mlh.ScreenScraping.Areas.Native.Services.Implementation
{
    internal class WebElementFetcher : IWebElementFetcher
    {
        public IReadOnlyCollection<WebElement> Fetch(object nativeObject)
        {
            var document = (IHTMLDocument2)nativeObject;
            var result = document
                .all
                .Cast<IHTMLElement>()
                .Select(f => new WebElement(f))
                .ToList();

            var tra = document.all.Cast<IHTMLElement>().ToList();

            var t = tra.Where(f => !string.IsNullOrEmpty(f.id)).ToList();
            var t2 = tra.Select(f => f.innerHTML).ToList();
            var elementwithids = result.Where(f => !string.IsNullOrEmpty(f.Id)).ToList();

            return result;
        }
    }
}