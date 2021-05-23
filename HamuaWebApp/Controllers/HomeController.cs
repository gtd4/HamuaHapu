using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HamuaHapuRegistration.Models;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using System.Text;
using HamuaHapuCommon.Resources;
using HamuaHapuRegistration.ApiClients.Interfaces;
using HamuaHapuRegistration.ViewModels;

namespace HamuaHapuRegistration.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IConfiguration config;
        private string apiBaseUrl;
        private INgaMaraeClient maraeClient;

        public HomeController(ILogger<HomeController> logger, IConfiguration _config, INgaMaraeClient client)
        {
            _logger = logger;
            config = _config;
            apiBaseUrl = config.GetValue<string>("hamuaApiBaseUrl") + "/ngatangata";
            maraeClient = client;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Register()
        {
            var vm = new RegisterViewModel();
            var ngaMarae = await maraeClient.GetNgaMaraeAsync();
            var maraeGrouping = ngaMarae.GroupBy(x => x.Area);

            vm.NgaMaraeGoup = maraeGrouping.OrderBy(x => x.Key);

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("FirstName,LastName,Gender,DOB,PlaceOfBirth,Occupation,SpecialtySkills,Address1,Address2,Address3,PostCode,Country,HomePhone,Mobile,Email,IsTeReoFirstLanguage,CanYouSpeakTeReo,TeReoProficiency,ReturnToRuatokiToLive,ReturnComment,Facebook,Twitter,Instagram,NgaMaraeIdList")] SaveTangataResource Member)
        {
            if (!ModelState.IsValid)
            {
                var vm = new RegisterViewModel();
                var ngaMarae = await maraeClient.GetNgaMaraeAsync();
                var maraeGrouping = ngaMarae.GroupBy(x => x.Area);
                vm.Member = Member;

                vm.NgaMaraeGoup = maraeGrouping.OrderBy(x => x.Key);

                ModelState.Clear();
                ModelState.AddModelError(string.Empty, "Error Creating Member");
                return View(vm);
            }
            using (HttpClient client = new HttpClient())
            {
                var jsonString = JsonConvert.SerializeObject(Member);

                var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                using (var response = await client.PostAsync(apiBaseUrl, httpContent))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.Created)
                    {
                        var stringResult = await response.Content.ReadAsStringAsync();
                        var tangata = JsonConvert.DeserializeObject<TangataResource>(stringResult);
                        return RedirectToAction(nameof(RegisterSuccess));
                    }
                    else
                    {
                        var vm = new RegisterViewModel();
                        var ngaMarae = await maraeClient.GetNgaMaraeAsync();
                        var maraeGrouping = ngaMarae.GroupBy(x => x.Area);

                        vm.NgaMaraeGoup = maraeGrouping;
                        vm.Member = Member;

                        ModelState.Clear();
                        ModelState.AddModelError(string.Empty, "Error Creating Member");
                        return View(vm);
                    }
                }
            }
        }

        public IActionResult RegisterSuccess()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}