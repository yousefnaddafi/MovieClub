using App.Core.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebApi.HttpServices
{
    public class HttpGetMovie
    {
        private readonly HttpClient client;
        private const string BaseAdress = "";

        public HttpGetMovie(HttpClient client)
        {
            this.client = client;
            this.client.BaseAddress = new Uri(BaseAdress);
            this.client.DefaultRequestHeaders.Add("Accept", "application/json");
        }
        public List<Movie> GetReq(Movie movie)
        {


            var json = JsonSerializer.Serialize(movie);
            var httpResponse = client.GetAsync($"api").Result;
            httpResponse.EnsureSuccessStatusCode();
            if (!httpResponse.IsSuccessStatusCode)
            {
                return null;
            }


            HttpContent content = httpResponse.Content;
            string stringContent = content.ReadAsStringAsync().Result;

            var result = JsonSerializer.Deserialize<Movie>(stringContent);
            var Movies = new List<Movie>();
            return Movies;
        }
    }
}
