namespace FSProduct_CategoryApi.Entities.Dtos.Products
{
    public class GetAllProductsDto
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public string CategoryName { get; set; }

    }
}
