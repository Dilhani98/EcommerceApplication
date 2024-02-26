namespace Ecommerce.APi.Search.Interface
{
    public interface ISearchInterface
    {
        Task<(bool IsSuccess, dynamic SearchResult)> SearchAsync(int customerId);
    }
}
