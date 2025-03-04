namespace Assignment3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>
            {
                new Product { ProductID = 1, Name = "Smartphone", Category = "Electronics", Price = 1500 },
                new Product { ProductID = 2, Name = "Laptop", Category = "Electronics", Price = 45000 },
                new Product { ProductID = 3, Name = "Headphones", Category = "Electronics", Price = 900 },
                new Product { ProductID = 4, Name = "Refrigerator", Category = "Appliances", Price = 25000 },
                new Product { ProductID = 5, Name = "Tablet", Category = "Electronics", Price = 1200 }
            };

            var mostExpensiveProduct = products.MaxBy(p => p.Price);
            Console.WriteLine($"\nThe most expensive product is: {mostExpensiveProduct.Name} with Price: Rs{mostExpensiveProduct.Price}");

        }
    }

    internal class Product
    {
        public int ProductID { get; set; }
        public String Name { get; set; }

        public String Category { get; set; }

        public double Price { get; set; }


    }
}
