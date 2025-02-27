using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exception_Handling.Exception;
using Exception_Handling.Modal;

namespace Exception_Handling.Repositary
{
    class BikeRepository:IBikeRepository
    {
       // List is storing the data List is type of collection
        List<Bike> bikes;
        // Bike[] //class array

        //defalt constructor
        public BikeRepository()
        {
            //Initializing the list
            bikes = new List<Bike>
            {
            new Bike(){Id=1,Name="ola",Price=20000M},
            new Bike(){Id=2,Name="Duke",Price=40000M}

            };
        }

        //public bool AddBike(Bike bike)
        //{
        //   Bike searchResult= GetBikeByName(bike.Name);
        //    if (searchResult == null)
        //    {
        //        bikes.Add(bike);
        //    }
        //    else 
        //    {
        //        throw new BikeAlreadyExistException($"{bike.Name}name already Exist");
        //    }


        //}

        public bool AddBike(Bike bike)
        {
            try
            {
                Bike searchResult = GetBikeByName(bike.Name);
                if (searchResult == null)
                {
                    bikes.Add(bike);
                    return true;
                }

                else
                {
                    //throw exception BikeAlreadyExistsException
                    throw new BikeAlreadyExistException($"{bike.Name} name already Exists");

                }

            }
            catch (BikeAlreadyExistException baex)
            {
                Console.WriteLine(baex.Message);
            }
            return false;
        }

        public List<Bike> GetAllBikes()
        {
           return bikes;
        }

        public Bike GetBikeByName(string name)
        {
            return bikes.Find(p => p.Name == name);
        }
    }
}
