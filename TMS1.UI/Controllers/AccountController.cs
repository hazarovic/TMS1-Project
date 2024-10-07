using Microsoft.AspNetCore.Mvc;
using TMS1.UI.Models.AccountViewModel;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using TMS1.UI.Models.MissionViewModel;

namespace TMS1.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly HttpClient _httpClient;

        public AccountController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (model != null)
            {
                var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("https://localhost:7282/api/Account/login", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("MissionList", "Mission");
                }
                else
                {
                    model.ErrorMessage = "Login failed. Please try again.";
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
            {
            if (ModelState.IsValid)
            {
                var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("https://localhost:7282/api/Account/register", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    model.ErrorMessage = "Registration failed. Please try again.";
                }
            }
            return View(model);
        }
        public async Task<IActionResult> GetAllMissions()
        {
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
        public IActionResult Logout()
        {

            return RedirectToAction("Login");
        }
    }
}
