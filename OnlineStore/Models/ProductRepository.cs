namespace OnlineStore.Models
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreDbContext _storeDbContext;

        public ProductRepository(StoreDbContext storeDbContext)
        {
            _storeDbContext = storeDbContext;
        }

        //public List<Product> GetAll(int pageNumber, int pageSize)
        public PagedData<Product> GetAll(int pageNumber, int pageSize)
        {
            using (_storeDbContext)
            {
                try
                {
                    // return _storeDbContext.Product.Skip((pageNumber-1)*pageSize).Take(pageSize).ToList();
                    var result = new PagedData<Product>
                    {
                        PageInfo = new PageInfo
                        {
                            PageSize = pageSize,
                            PageNumber = pageNumber
                        }
                    };

                    result.Data = _storeDbContext.Product.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
                    result.PageInfo.TotalCount = _storeDbContext.Product.Count();
                    return result;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
