
namespace MiniBlog.EndPoint.Shared.Models
{
    public class PagedData<T>
    {
        public List<T>? QueryResult { get; set; }
    }
}
