namespace FSProduct_CategoryApi.Entities.Dtos.Products
{
    public class CreateProductDto
    {
       
        public string Name { get; set; }
        public string Desc { get; set; }
        public decimal Price { get; set; }

        public int CategoryId { get; set; }
    }
}
