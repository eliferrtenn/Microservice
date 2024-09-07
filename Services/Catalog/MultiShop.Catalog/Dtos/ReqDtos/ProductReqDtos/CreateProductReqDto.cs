namespace MultiShop.Catalog.Dtos.ReqDtos.ProductReqDtos
{
    public class CreateProductReqDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string CategoryId { get; set; }
    }
}