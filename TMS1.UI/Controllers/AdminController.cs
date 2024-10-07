using Microsoft.AspNetCore.Mvc;
using TMS1.UI.Models.AccountViewModel;
using TMS1.UI.Models.MissionViewModel;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http.Headers;

namespace TMS1.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly HttpClient _httpClient;

        public AdminController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAccounts(string username)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7282/api/Admin/accounts?username={username}");
            if (response.IsSuccessStatusCode)
            {
                var accounts = JsonConvert.DeserializeObject<IEnumerable<RegisterViewModel>>(await response.Content.ReadAsStringAsync());
                return View(accounts);
            }
            return View(new List<RegisterViewModel>());
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("https://localhost:7282/api/Admin/accounts", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("GetAllAccounts");
                }
                else
                {
                    model.ErrorMessage = "Account creation failed. Please try again.";
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMissions()
        {
            var token = HttpContext.Session.GetString("Token");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync("https://localhost:7282/api/Admin/missions");
            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                var missions = JsonConvert.DeserializeObject<IEnumerable<MissionDetailsViewModel>>(responseData);
                return View(missions);
            }
            return View(new List<MissionDetailsViewModel>());
        }

        [HttpPost]
        public async Task<IActionResult> SaveMission(CreateMissionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("https://localhost:7282/api/Admin/missions/save", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("GetAllMissions");
                }
                else
                {
                    model.ErrorMessage = "Mission save failed. Please try again.";
                }
            }
            return View(model);
        }
    }
}
