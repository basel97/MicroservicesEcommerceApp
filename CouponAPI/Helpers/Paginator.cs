namespace CouponAPI.Helpers
{
    public class Paginator<T> : List<T>
    {
        public int PageNumber { get; private set; }
        public int PageSize { get; private set; }
        public int TotalPages { get; private set; }
        public int TotalCount { get; private set; }
        public Paginator(IEnumerable<T> data, int pageNumber, int pageSize, int count)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalCount = count;
            TotalPages = (int)Math.Ceiling((double)count / pageSize);
            AddRange(data);
        }
        public static Paginator<T> CreatePagination(IEnumerable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var paginatedData = source.Skip((pageNumber - 1) * pageSize).Take(pageSize);
            return new Paginator<T>(paginatedData, pageNumber, pageSize, count);
        }
    }
}
