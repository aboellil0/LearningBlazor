namespace LearningBlazor.Components.Models
{
    public class Product
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }
        public bool IsAvailable { get; set; }
        public IEnumerable<ProductPropriety> productProprieties { get; set; }
    }
    public class ProductPropriety
    {
        public string Name { get; set; } 
        public string Value { get; set; }
    }
}
