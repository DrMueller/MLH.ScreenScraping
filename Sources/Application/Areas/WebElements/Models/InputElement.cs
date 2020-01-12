using mshtml;

namespace Mmu.Mlh.ScreenScraping.Areas.WebElements.Models
{
    public class InputElement : WebElement
    {
        private readonly IHTMLInputElement _nativeElement;

        internal InputElement(IHTMLInputElement nativeElement) : base((IHTMLElement)nativeElement)
        {
            _nativeElement = nativeElement;
        }

        public void SetValue(string value)
        {
            _nativeElement.value = value;
        }
    }
}