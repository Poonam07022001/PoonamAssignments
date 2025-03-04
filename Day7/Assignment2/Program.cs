namespace Assignment2
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


           // LINQ to find Electronics products costing more than Rs1000
           var expensiveElectronics =
                                       from product in products
                                       where product.Category == "Electronics" && product.Price > 1000
                                       select product;

            // Display filtered products
            Console.WriteLine("Electronics products costing more than Rs1000:");
            foreach (var product in expensiveElectronics)
            {
                Console.WriteLine($"ProductID: {product.ProductID}, Name: {product.Name}, Price: Rs{product.Price}");
            }


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
