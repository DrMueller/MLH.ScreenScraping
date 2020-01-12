using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Mmu.Mlh.ScreenScraping.Areas.Browsers.Services;
using Mmu.Mlh.ScreenScraping.Areas.WebElements.Models;

namespace Mmu.Mlh.ScreenScraping.TestUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
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
            await browser.Navigate("https://stackoverflow.com/");

            var element = browser.Find<InputElement>(f => f.ByClassName("s-input s-input__search js-search-field"));
            element.SetValue("tra");
        }
    }
}
