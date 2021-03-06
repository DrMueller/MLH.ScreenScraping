﻿using System.Diagnostics;
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
            var browser = _browserFactory.Create(WebBrowser, InfoCallback);
            await browser.Navigate("https://www.google.ch");

            browser
                .Find<InputElement>(f => f.ByClassName("gLFyf gsfi"))
                .SetValue("Hello Google!");
        }

        private static void InfoCallback(string info)
        {
            Debug.WriteLine(info);
        }
    }
}