using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Modal
{
    class Person
    {
        public int AccoutNumber { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"Account Number:: {AccoutNumber} Name:: {Name}";
        }
    }
}
