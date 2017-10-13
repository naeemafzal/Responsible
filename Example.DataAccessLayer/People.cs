using System;
using System.Collections.Generic;
using System.Linq;
using Responsible.Core;

namespace Example.DataAccessLayer
{
    public class People
    {
        //Our in memory database (so to say...)
        private static readonly List<Person> PeopleList = new List<Person>();

        public IResponse AddPerson(Person person)
        {
            try
            {
                if (string.IsNullOrEmpty(person.Fullname))
                {
                    var errorMessage = $"Person name is not provided";
                    return ResponseFactory<Person>.Error(errorMessage);
                }

                //Add in database
                person.Id = PeopleList.Count() + 1;
                PeopleList.Add(person);
                return ResponseFactory.Ok($"{person.Fullname} has been added.");
            }
            catch (Exception ex)
            {
                return ResponseFactory.Exception(ex, ex.Message);
            }
        }

        public IResponse<Person> GetPerson(int id)
        {
            try
            {
                var person = PeopleList.FirstOrDefault(p => p.Id == id);
                if (person == null)
                {
                    var errorMessage = $"Could not find Person with Id: {id}";
                    return ResponseFactory<Person>.Error(errorMessage, ErrorResponseStatus.NotFound);
                }

                return ResponseFactory<Person>.Ok(person);
            }
            catch (Exception ex)
            {
                return ResponseFactory<Person>.Exception(ex, ex.Message);
            }
        }

        public IResponse UpdatePerson(Person person)
        {
            return ResponseFactory<Person>.NotImplemented();
            // Or return a custom message as following
            return ResponseFactory<Person>.NotImplemented("This feature will be available from next month.");
        }
    }
}
