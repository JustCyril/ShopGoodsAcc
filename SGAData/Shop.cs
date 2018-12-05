using System;

namespace SGAData
{
    public class Shop
    {
        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }

        public Shop(int id, string name, string address)
        {
            this.id = id;
            this.name = name;
            this.address = address;
        }
    }
}
