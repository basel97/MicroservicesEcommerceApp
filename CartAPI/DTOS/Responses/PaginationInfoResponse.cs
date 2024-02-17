namespace CartAPI.DTOS.Responses
{
    public class PaginationInfoResponse
    {
        public PaginationInfoResponse(int currentPage, int itemsPerPage, int totalItems, int totalPages)
        {
            CurrentPage = currentPage;
            ItemsPerPage = itemsPerPage;
            TotalItems = totalItems;
            TotalPages = totalPages;
        }

        public int CurrentPage { get; private set; }
        public int ItemsPerPage { get; private set; }
        public int TotalItems { get; private set; }
        public int TotalPages { get; private set; }

    }
}
