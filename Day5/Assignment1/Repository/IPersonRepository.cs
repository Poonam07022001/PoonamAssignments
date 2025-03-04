using Assignment1.Modal;

namespace Assignment1.Repository
{
    interface IPersonRepository
    {
        bool AddPerson(Person person);
        List<Person> GetAllPerson();
        Person GetPersonByAccountNumber(int AccountNumber);
    }
}
