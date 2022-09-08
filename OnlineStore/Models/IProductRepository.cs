namespace OnlineStore.Models
{
    public interface IProductRepository
    {
        //List<Product> GetAll(int pageNumber,int pageSize);
        PagedData<Product> GetAll(int pageNumber, int pageSize);
    }
}
