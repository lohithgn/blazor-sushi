namespace BlazorSushi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public bool Featured { get; set; }
        public Stats Stats { get; set; }
    }
}
