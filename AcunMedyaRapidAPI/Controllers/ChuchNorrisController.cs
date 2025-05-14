using AcunMedyaRapidAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AcunMedyaRapidAPI.Controllers
{
    public class ChuchNorrisController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://matchilling-chuck-norris-jokes-v1.p.rapidapi.com/jokes/random"),
                Headers =
    {
        { "x-rapidapi-key", "f3199434e5msh58ee98c4e68e750p14cb70jsn56545f8ecbb0" },
        { "x-rapidapi-host", "matchilling-chuck-norris-jokes-v1.p.rapidapi.com" },
        { "accept", "application/json" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ChuchNorrisViewModel>(body);
                return View(value);
            }
        }
    }
}
