using System;

namespace ShopGoodsAcc.Data
{
    public class Shop
    {
        public int id;
        public string name;
        public string address;

        public Shop(int id, string name, string address)
        {
            this.id = id;
            this.name = name;
            this.address = address;
        }
    }
}
