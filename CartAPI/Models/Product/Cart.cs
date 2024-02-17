namespace CartAPI.Models.Product
{
    public class Cart : BaseModel
    {
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public double CurrentPrice { get; set; }
        public int Count { get; set; }
    }
}
