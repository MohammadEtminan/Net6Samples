namespace OnlineStore.Models
{
    public interface IRepository<T>
    {
        List<T> GetAll();
    }
}
