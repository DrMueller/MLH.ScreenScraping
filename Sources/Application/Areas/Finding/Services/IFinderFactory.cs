namespace Mmu.Mlh.ScreenScraping.Areas.Finding.Services
{
    public interface IFinderFactory
    {
        IFinder ByClassName(string className);

        IFinder ById(string id);

        IFinder ByTagName(string tagName);

        IFinder ByInnerText(string text);
    }
}