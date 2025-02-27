using System.Diagnostics;
using Assignement.Modal;

namespace Assignement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();

            // Accept car details
            car.AcceptCarDetails();

            // Display car details
            car.DisplayCarDetails();


        }
    }
}
