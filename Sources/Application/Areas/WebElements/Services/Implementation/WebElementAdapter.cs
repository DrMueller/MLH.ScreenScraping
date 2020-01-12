using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Mmu.Mlh.ScreenScraping.Areas.WebElements.Models;

namespace Mmu.Mlh.ScreenScraping.Areas.WebElements.Services.Implementation
{
    internal class WebElementAdapter : IWebElementAdapter
    {
        public T Adapt<T>(WebElement element)
            where T : WebElement
        {
            var ctor = typeof(T).GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance).Single();

            var ctorParameter = ctor.GetParameters().Single();

            var newNativeElement = Convert.ChangeType(element.NativeElement, ctorParameter.ParameterType);
            var arr = new List<object> { newNativeElement }.ToArray();

            var newObject = ctor.Invoke(arr);
            var result = (T)newObject;

            return result;
        }
    }
}