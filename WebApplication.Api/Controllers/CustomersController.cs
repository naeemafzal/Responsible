using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Responsible.WebApi.ResponsibleAttributes;
using WebApplication.Api.Logic;
using WebApplication.Api.Models;

namespace WebApplication.Api.Controllers
{
    /// <summary>
    /// User interface
    /// </summary>
    [RoutePrefix("Customers")]
    public class CustomersController : Responsible.WebApi.ResponsibleController
    {
        /// <summary>
        /// Get Customer by Id
        /// </summary>
        /// <param name="id">Id of the customer to load</param>
        /// <returns>Return <see cref="Customer"/></returns>
        [Route("{id}")]
        [HttpGet]
        [ResponseType(typeof(Customer))]
        public HttpResponseMessage Get(int id)
        {
            var customerResponse = CustomerLogic.Get(id);
            return CreateResponse(customerResponse);
        }

        /// <summary>
        /// Gets a filtered list of Customers
        /// </summary>
        /// <param name="search">Text to search customers</param>
        /// <returns>Return <see cref="Customer"/></returns>
        [Route("Search/{search}")]
        [HttpGet]
        [ResponseType(typeof(List<Customer>))]
        public HttpResponseMessage Get(string search)
        {
            var customerResponse = CustomerLogic.Find(search);
            return CreateResponse(customerResponse);
        }


        /// <summary>
        /// Adds a customer
        /// </summary>
        /// <param name="customer">A <see cref="Customer"/> object to be added.</param>
        /// <returns>Unique Id of newly added customer <see cref="int"/></returns>
        [Route("Add")]
        [HttpPut]
        [ResponseType(typeof(int))]
        [ValidateModelState]
        public HttpResponseMessage Add(Customer customer)
        {
            var customerResponse = CustomerLogic.Add(customer);
            return CreateResponse(customerResponse);
        }
    }
}