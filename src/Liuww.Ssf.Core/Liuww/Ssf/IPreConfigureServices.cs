using Liuww.Ssf.Modularity;

namespace Liuww.Ssf
{
    public interface IPreConfigureServices
    {
        void PreConfigureServices(ServiceConfigurationContext context);
    }
}