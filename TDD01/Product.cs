namespace TDD01
{
    public class Product
    {
        public Product(string name, double price, int? discount = null)
        {
            Name = name;
            Price = price;
            Discount = discount;
        }

        public string Name { get; }
        public double Price { get; }
        public int? Discount { get; }
    }
}