namespace FSProduct_CategoryApi.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public decimal Price { get; set; }
        public DateTime CreateAt { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
