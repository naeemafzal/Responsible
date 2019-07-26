﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WindowsForms.App.Models;
using Responsible.Core;
using Responsible.Handler.WebApi;

namespace WindowsForms.App.Logic
{
    internal class CustomerLogic
    {
        private static readonly string _webApiAddress = "http://localhost:58817/";

        internal static IResponse<List<Customer>> Filter(string search)
        {
            using (var client = new ResponsibleHttpClient(_webApiAddress))
            {
                Thread.Sleep(TimeSpan.FromSeconds(3));
                var customerResponse = client.Get<List<Customer>>($"Customers/Search/{search}");
                return customerResponse;
            }
        }

        internal static async Task<IResponse<List<Customer>>> FilterAsync(string search, CancellationToken cancellationToken)
        {
            using (var client = new ResponsibleHttpClient(_webApiAddress))
            {
                var customerResponse = await client.GetAsync<List<Customer>>($"Customers/Search/{search}", cancellationToken);
                return customerResponse;
            }
        }

        internal static IResponse<int> Add(Customer customer)
        {
            Thread.Sleep(TimeSpan.FromSeconds(3));
            using (var client = new ResponsibleHttpClient(_webApiAddress))
            {
                var addResponse = client.Put<Customer, int>("Customers/Add", customer, MediaFormat.JSon);
                return addResponse;
            }
        }
    }
}
