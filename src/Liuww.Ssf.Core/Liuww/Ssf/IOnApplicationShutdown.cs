namespace Liuww.Ssf
{
    public interface IOnApplicationShutdown
    {
        void OnApplicationShutdown(ApplicationShutdownContext context);
    }
}