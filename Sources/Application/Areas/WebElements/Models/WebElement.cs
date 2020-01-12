using mshtml;

namespace Mmu.Mlh.ScreenScraping.Areas.WebElements.Models
{
    public class WebElement
    {
        public string Id => NativeElement.id;
        public string ClassName => NativeElement.className;
        internal IHTMLElement NativeElement { get; }

        internal WebElement(IHTMLElement nativeElement)
        {
            NativeElement = nativeElement;
        }
    }
}