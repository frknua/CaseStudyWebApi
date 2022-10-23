using CaseStudy.Core.Repositories;
using CaseStudy.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaseStudy.Core.Models;
using System.Threading;
using RestSharp.Authenticators;
using RestSharp;
using Newtonsoft.Json;

namespace CaseStudy.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public class Result
        {
            public List<Product> Products { get; set; }
        }

        public async Task<List<Product>> GetAllProducts()
        {
            var url = Environment.GetEnvironmentVariable("ProductsUrl");
            var client = new RestClient(url); 
            var request = new RestRequest();           
            var result = await client.GetAsync(request);
            if (result.IsSuccessful)
            {
                var converted = JsonConvert.DeserializeObject<Result>(result.Content);
                if (converted != null)
                {
                    return converted.Products;
                }
            }
            return new List<Product>();
        }

        public async Task<Product> GetProductById(int id)
        {
            var url = Environment.GetEnvironmentVariable("ProductDetailUrl");
            var client = new RestClient(string.Concat(url,id.ToString()));          
            var request = new RestRequest();
            var result = await client.GetAsync(request);            
            if (result.IsSuccessful)
            {
                var converted = JsonConvert.DeserializeObject<Product>(result.Content);
                if (converted != null)
                {
                    return converted;
                }
            }
            return new Product();
        }
    }
}
