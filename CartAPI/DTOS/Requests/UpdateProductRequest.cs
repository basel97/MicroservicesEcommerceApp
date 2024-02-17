namespace CartAPI.DTOS.Requests
{
    public class UpdateProductRequest
    {
        public Guid Id { get; set; }
        public double CurrentPrice { get; set; }
        public int Count { get; set; }
    }
}
