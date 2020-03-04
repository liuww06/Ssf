namespace Liuww.Ssf.DependencyInjection
{
    public interface IObjectAccessor<out T>
    {
        T Value { get; }
    }
}