using System;
using System.Globalization;

namespace Liuww.Ssf.Localization
{
    public static class CultureHelper
    {
        public static IDisposable Use(string culture, string uiCulture = null)
        {
            return Use(new CultureInfo(culture), uiCulture == null ? null : new CultureInfo(uiCulture));
        }

        public static IDisposable Use(CultureInfo culture, CultureInfo uiCulture = null)
        {
            var currentCulture = CultureInfo.CurrentCulture;
            var currentUiCulture = CultureInfo.CurrentUICulture;

            CultureInfo.CurrentCulture = culture;
            CultureInfo.CurrentUICulture = uiCulture ?? culture;

            return new DisposeAction(() =>
            {
                CultureInfo.CurrentCulture = currentCulture;
                CultureInfo.CurrentUICulture = currentUiCulture;
            });
        }
    }
}