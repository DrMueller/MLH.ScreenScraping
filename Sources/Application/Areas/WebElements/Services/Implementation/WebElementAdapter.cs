using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Mmu.Mlh.ScreenScraping.Areas.WebElements.Models;

namespace Mmu.Mlh.ScreenScraping.Areas.WebElements.Services.Implementation
{
    internal class WebElementAdapter : IWebElementAdapter
    {
        private static readonly Type _webElemenType = typeof(WebElement);

        public T Adapt<T>(WebElement element)
            where T : WebElement
        {
            var targetType = typeof(T);

            if (targetType == _webElemenType)
            {
                return (T)element;
            }

            var ctor = targetType.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance).Single();
            var arr = new List<object> { element.NativeElement }.ToArray();

            var newObject = ctor.Invoke(arr);
            var result = (T)newObject;

            return result;
        }
    }
}