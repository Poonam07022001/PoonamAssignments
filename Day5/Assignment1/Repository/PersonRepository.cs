using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Repository
{
    class PersonRepository:IPersonRepository
    {
        List<Person> person;

        public PersonRepository()
        {
            person = new List<Person>
            {
                new Person(){ AccoutNumber=34322,Name="hdfc"},
                new Person(){ AccoutNumber=12322,Name="hdfc"}
            };

        }
    }
}
