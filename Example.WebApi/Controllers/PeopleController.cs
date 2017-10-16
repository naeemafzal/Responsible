using System.Net.Http;
using System.Web.Mvc;
using Example.DataAccessLayer;
using Responsible.WebApi;

namespace Example.WebApi.Controllers
{
    public class PeopleController : ResponsibleController
    {
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var findPersonResponse = new People().GetPerson(id);
            return CreateResponse(findPersonResponse);
        }
    }
}