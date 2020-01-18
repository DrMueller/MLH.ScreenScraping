using System;
using System.Windows.Controls;
using Mmu.Mlh.ScreenScraping.Areas.Browsers.Models;

namespace Mmu.Mlh.ScreenScraping.Areas.Browsers.Services
{
    public interface IBrowserFactory
    {
        IBrowser Create(WebBrowser webBrowser, Action<string> infoCallback);
    }
}