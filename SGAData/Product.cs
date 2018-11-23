
namespace SGAData
{
    public class Product
    {
        public int id;
        public string name;
        public string description;
        public int amount;
        public Shop shop;

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
