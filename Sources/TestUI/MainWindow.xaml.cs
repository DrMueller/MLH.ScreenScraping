using System.Diagnostics;
using System.Linq;
using System.Windows;
using Mmu.Mlh.ScreenScraping.Areas.Browsers.Services;
using Mmu.Mlh.ScreenScraping.Areas.WebElements.Models;

namespace Mmu.Mlh.ScreenScraping.TestUI
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
            var browser = _browserFactory.Create(WebBrowser, InfoCallback);
            await browser.Navigate("https://www.google.ch");

            browser
                .Find<WebElement>(f => f.ByClassName("gLFyf gsfi"))
                .Click();
        }

        private static void InfoCallback(string obj)
        {
            Debug.WriteLine(obj);
        }
    }
}