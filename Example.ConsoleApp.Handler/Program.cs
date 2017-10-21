using System;
using Example.DataAccessLayer;

namespace Example.ConsoleApp.Handler
{
    class Program
    {
        static void Main(string[] args)
        {
            var addResponse = new People().AddPerson(null); //Exception response (NullRefException)
            Responsible.Handler.Console.Handler.HandleResponse("Adding Person", addResponse, true);
            Console.WriteLine("===============================================");

            var person = new Person() { Fullname = null };
            addResponse = new People().AddPerson(person); //Error response (Name not provided)
            Responsible.Handler.Console.Handler.HandleResponse("Adding Person", addResponse, true);
            Console.WriteLine("===============================================");

            person = new Person() { Fullname = "Naeem Afzal" };
            addResponse = new People().AddPerson(person); //Ok Response
            Responsible.Handler.Console.Handler.HandleResponse("Adding Person", addResponse, true);
            Console.WriteLine("===============================================");

            var loadPerson = new People().GetPerson(1);
            Responsible.Handler.Console.Handler.HandleResponse("Load Person", loadPerson); //Ok Response with a value
            if (loadPerson.Success)
            {
                var loadedPerson = loadPerson.Value; //Taking value from the response
                Console.WriteLine($@"Name: {loadedPerson?.Fullname}"); //Printing name
                Console.WriteLine("===============================================");

            }
            var updateResponse = new People().UpdatePerson(new Person()); //Not implemented response
            Responsible.Handler.Console.Handler.HandleResponse("Update Person", updateResponse, true);


            Console.ReadLine();
        }
    }
}
