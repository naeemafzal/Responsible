using System;
using Example.DataAccessLayer;
using Responsible.Handler.Console;

namespace Example.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var addResponse = new People().AddPerson(null); //Exception response (NullRefException)
            Handler.HandleResponse("Adding Person", addResponse, true);
            Console.WriteLine("===============================================");

            var person = new Person() { Fullname = null };
            addResponse = new People().AddPerson(person); //Error response (Name not provided)
            Handler.HandleResponse("Adding Person", addResponse, true);
            Console.WriteLine("===============================================");

            person = new Person() { Fullname = "Naeem Afzal" };
            addResponse = new People().AddPerson(person); //Ok Response
            Handler.HandleResponse("Adding Person", addResponse, true);
            Console.WriteLine("===============================================");

            var loadPerson = new People().GetPerson(1);
            Handler.HandleResponse("Load Person", loadPerson); //Ok Response with a value
            if (loadPerson.Success)
            {
                var loadedPerson = loadPerson.Value; //Taking value from the response
                Console.WriteLine($@"Name: {loadedPerson?.Fullname}"); //Printing name
                Console.WriteLine("===============================================");

            }
            var updateResponse = new People().UpdatePerson(new Person()); //Not implemented response
            Handler.HandleResponse("Update Person", updateResponse, true);


            Console.ReadLine();
        }
    }
}
