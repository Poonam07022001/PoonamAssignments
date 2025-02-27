using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignement.Modal
{
    internal class Car
    {
        int CarID;
         string Brand;
        string Model;
        int Year;
        double Price;


        public void AcceptCarDetails()
        {
            Console.WriteLine("Receiving Car Information");

            Console.Write("Enter Car ID: ");
            CarID = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Brand: ");
            Brand = Console.ReadLine();

            Console.Write("Enter Model: ");
            Model = Console.ReadLine();

            Console.Write("Enter Manufacturing Year: ");
            Year = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Price: ");
            Price = Convert.ToDouble(Console.ReadLine());
        }

        public void DisplayCarDetails()
        {
            Console.WriteLine("\nPresenting Car Information");
            Console.WriteLine($"Car ID: {CarID}");
            Console.WriteLine($"Brand: {Brand}");
            Console.WriteLine($"Model: {Model}");
            Console.WriteLine($"Year: {Year}");
            Console.WriteLine($"Price: {Price:C}");
        }
    }




}
