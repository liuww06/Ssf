using Liuww.Ssf.Modularity;

namespace Liuww.Ssf
{
    public interface IPostConfigureServices
    {
        void PostConfigureServices(ServiceConfigurationContext context);
    }
}