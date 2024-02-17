namespace CartAPI.DTOS.Responses
{
    public class UserCartRespone
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public double CurrentPrice { get; set; }
        public int Count { get; set; }
        public ProductRespone? Product { get; set; }
    }
}
