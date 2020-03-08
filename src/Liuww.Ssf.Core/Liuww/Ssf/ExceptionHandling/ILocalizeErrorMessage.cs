using Liuww.Ssf.Localization;

namespace Liuww.Ssf.ExceptionHandling
{
    public interface ILocalizeErrorMessage
    {
        string LocalizeMessage(LocalizationContext context);
    }
}