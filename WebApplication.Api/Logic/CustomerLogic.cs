using System;
using System.Collections.Generic;
using Responsible.Core;
using WebApplication.Api.Data;
using WebApplication.Api.Models;

namespace WebApplication.Api.Logic
{
    public class CustomerLogic
    {
        public static IResponse<List<Customer>> Find(string name)
        {
            try
            {
                var result = new CustomersData().Find(name);
                return ResponseFactory<List<Customer>>.Ok(result, $"{result.Count} records found.");
            }
            catch (Exception ex)
            {
                return ResponseFactory<List<Customer>>.Exception(ex);
            }
        }

        public static IResponse<Customer> Get(int id)
        {
            try
            {
                var result = new CustomersData().Get(id);
                if (result == null)
                {
                    return ResponseFactory<Customer>.Error($"Could not find a record with Id: {id}", ErrorResponseStatus.NotFound);
                }

                return ResponseFactory<Customer>.Ok(result);
            }
            catch (Exception ex)
            {
                return ResponseFactory<Customer>.Exception(ex);
            }
        }

        public static IResponse<int> Add(Customer customer)
        {
            try
            {
                if (customer == null)
                {
                    return ResponseFactory<int>.Error("Invalid customer data.", ErrorResponseStatus.BadRequest);
                }

                var customerId = new CustomersData().Add(customer);
                return ResponseFactory<int>.Ok(customerId, "Customer has been added.");
            }
            catch (Exception ex)
            {
                return ResponseFactory<int>.Exception(ex);
            }
        }

        public static IResponse Update(Customer customer)
        {
            return ResponseFactory.NotImplemented("This feature will be available at the end of 2018.");
        }
    }
}