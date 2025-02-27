using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exception_Handling.Exception
{
    internal class BikeAlreadyExistException : ApplicationException
    {
        //deflalt constructor
        public BikeAlreadyExistException() 
        {
        
        }
        
        //Parameterized constructor
        public BikeAlreadyExistException(string msg) : base(msg)
            {
        
        }
    }
}
