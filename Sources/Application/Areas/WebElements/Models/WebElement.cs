using mshtml;

namespace Mmu.Mlh.ScreenScraping.Areas.WebElements.Models
{
    public class WebElement
    {
        public string ClassName => NativeElement.className ?? string.Empty;
        public string Id => NativeElement.id ?? string.Empty;
        public string InnerText => NativeElement.innerText ?? string.Empty;
        public string TagName => NativeElement.tagName ?? string.Empty;

        internal IHTMLElement NativeElement { get; }

        internal WebElement(IHTMLElement nativeElement)
        {
            NativeElement = nativeElement;
        }

        public void Click()
        {
            NativeElement.click();
        }
    }
}