namespace ProductAPI.DTOS.Responses
{
    public class ProductRespone
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public double DiscountPrice { get; set; }
        public double SoldItems { get; set; }
        public string? ImgUrl { get; set; }
    }
}
