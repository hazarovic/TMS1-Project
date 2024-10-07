using Microsoft.AspNetCore.Mvc;
using TMS1.UI.Models.MissionViewModel;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using System.Collections.Generic;
using TMS1.UI.Models.Entities;

namespace TMS1.UI.Controllers
{
    public class MissionController : Controller
    {
        private readonly HttpClient _httpClient;

        public MissionController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> MissionList()
        {
            var response = await _httpClient.GetAsync("https://localhost:7282/api/Mission/");
            if (response.IsSuccessStatusCode)
            {
                var missions = JsonConvert.DeserializeObject<IEnumerable<MissionView>>(await response.Content.ReadAsStringAsync());
                return View(missions);
            }
            return View();

        }

        // Diğer metodlar...
    }
}
