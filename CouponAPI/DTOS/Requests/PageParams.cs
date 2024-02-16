namespace CouponAPI.DTOS.Requests
{
    public class PageParams
    {
        private const int MaxPageSize = 20;
        public int PageNumber { get; set; } = 1; // always return 1 page unless the user want something else
        private int _pageSize = 10;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value; // if more than 50 return 50 if 40 return 40
        }
    }
}
