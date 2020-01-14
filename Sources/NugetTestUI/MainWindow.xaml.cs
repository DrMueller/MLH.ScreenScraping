using System.Linq;
using System.Windows;
using Mmu.Mlh.ScreenScraping.Areas.Browsers.Services;
using Mmu.Mlh.ScreenScraping.Areas.WebElements.Models;

namespace Mmu.Mlh.ScreenScraping.NugetTestUI
{
    public partial class MainWindow
    {
        private readonly IBrowserFactory _browserFactory;

        public MainWindow(IBrowserFactory browserFactory)
        {
            _browserFactory = browserFactory;
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var browser = _browserFactory.Create(WebBrowser);
            await browser.Navigate("https://www.google.ch");

            browser
                .Find<InputElement>(f => f.ById("UsernameOrEmail"))
                .SetValue("SomeValue");

            browser
                .Find<InputElement>(f => f.ById("Password"))
                .SetValue("SomeValue");

            browser
                .Find<WebElement>(f => f.ByClassName("btn btn-primary"))
                .Click();

            await browser.WaitForPageToLoad("https://www.google.ch");

            browser
                .FindAll(f => f.ByInnerText("Benutzerkonten"))
                .Single(f => f.TagName.ToUpperInvariant() == "BUTTON")
                .Click();
        }
    }
}