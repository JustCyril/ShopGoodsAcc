
namespace SGAData
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int amount { get; set; }
        public Shop shop { get; set; }

        public Product(int id, string name, string description, int amount, Shop shop)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.amount = amount;
            this.shop = shop;
        }
  

    }
}
