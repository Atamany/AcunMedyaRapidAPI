using AcunMedyaRapidAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace AcunMedyaRapidAPI.Controllers
{
    public class IMDBSeriesController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/series/"),
                Headers =
    {
        { "x-rapidapi-key", "f3199434e5msh58ee98c4e68e750p14cb70jsn56545f8ecbb0" },
        { "x-rapidapi-host", "imdb-top-100-movies.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<IMDBSeriesViewModel>>(body);
                return View(value);
            }
        }
    }
}
