using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;
using Responsible.Core;
using Responsible.WebApi;

namespace Example.WebApi.Controllers
{
    public class CategoryController : ResponsibleController
    {
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var response = ResponseFactory<int>.Ok(id, new List<string>() {$"Id is: {id}", "Message 2"});
            return CreateResponse(response);
        }
    }
}