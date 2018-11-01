using System;
using System.Collections.Generic;

namespace ShopGoodsAcc.Data
{
    public class DataGenerator
    {
        public static List<Product> products;
        public static List<Shop> shops;

        public DataGenerator()
        {
            products = new List<Product>();
            shops = new List<Shop>();

            Shop meteor = new Shop(0, "Метеор", "Харьковская 10");
            Shop fakel = new Shop(1, "Факел", "Линейная 7");
            Shop mirazh = new Shop(2, "Мираж", "Широтная 122");

            shops.Add(meteor);
            shops.Add(fakel);
            shops.Add(mirazh);

            Product hleb = new Product(0, "хлеб", "белый хлеб в форме кирпича", 20, meteor);
            Product spichki1 = new Product(1, "спички", "спички бытовые", 10, fakel);
            Product spichki2 = new Product(2, "спички", "спички бытовые", 10, meteor);
            Product dvorniki = new Product(3, "дворники", "щетки стеклоочистителей в сборе", 5, mirazh);

            products.Add(hleb);
            products.Add(spichki1);
            products.Add(spichki2);
            products.Add(dvorniki);

        }

    }
}
