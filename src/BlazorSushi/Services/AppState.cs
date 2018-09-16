using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Blazor;
using BlazorSushi.Models;

namespace BlazorSushi.Services
{
    public class AppState
    {
        public IReadOnlyList<Product> Products {get; private set;}
        public Cart Cart { get; } = new Cart();
        
        private readonly HttpClient http;
        public AppState(HttpClient httpInstance)
        {
            http = httpInstance;
        }

        public async Task LoadProducts()
        {
            if(Products == null)
            {
                Products = await http.GetJsonAsync<Product[]>("/data/menu.json");
            }
        }

        public Product LoadProduct(int productId)
        {
            return Products.SingleOrDefault(product => product.Id == productId);
        }
    }

}