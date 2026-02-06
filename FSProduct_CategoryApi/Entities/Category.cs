namespace FSProduct_CategoryApi.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateAt { get; set; }
        public List<Product> Products { get; set; }
    }
}
