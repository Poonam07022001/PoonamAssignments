using Exception_Handling.Modal;
using Exception_Handling.Repositary;

namespace Exception_Handling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region
            //Console.WriteLine("Enter your Id::");
            //int userinput=int.Parse(Console.ReadLine());

            //string[] cities = { "Mumbai", "Chennai" };
            //for (int i = 0; i <=cities.Length; i++)
            //{
            //    Console.WriteLine(cities[i]);
            //}


            //try
            //{
            //    Console.WriteLine("Enter your Id::");
            //    int userinput = int.Parse(Console.ReadLine());
            //}
            ////catch (Exception ex)
            ////{
            ////    Console.WriteLine(ex.Message);
            ////}
            //catch (FormatException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            //catch (OverflowException oex)
            //{
            //    Console.WriteLine(oex.Message);
            //}

            //finally {
            //    Console.WriteLine("This block get executed always");
            //        }
            #endregion
          
            IBikeRepository bikeRepo = new BikeRepository();
            List<Bike>allBikes= bikeRepo.GetAllBikes();
            //foreach(Bike bike in allBikes)
            //{
            //    Console.WriteLine(bike);

            //}
            Bike bike3 = new Bike()
            {
                Id = 3,
                Name = "Duke",
                Price = 100000M
            };
            bool addStatus = bikeRepo.AddBike(bike3);
            if (addStatus)
            {
                Console.WriteLine("Bike Added Successfully");
            }
            else { Console.WriteLine("Try new name ::"); }
        }

    }
}