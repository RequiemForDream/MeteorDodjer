namespace Core.Interfaces
{
    public interface IListenersHandler<T>
    {
        void AddListener(T listener);
        void RemoveListener(T listener);
    }
}
