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
using Microsoft.AspNetCore.Authorization;

namespace HamuaHapuRegistration.Controllers
{
    [AllowAnonymous]
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

        private static List<SaveTupunaResource> PopulateTupunaList()
        {
            var ngaTupuna = new List<SaveTupunaResource>();
            //for (var i = 0; i < 7; i++)
            //{
            //    ngaTupuna.Add(new SaveTupunaResource());
            //}
            var mama = new SaveTupunaResource { Relationship = "Mother" };
            var papa = new SaveTupunaResource { Relationship = "Father" };

            ngaTupuna.Add(mama);
            ngaTupuna.Add(papa);

            return ngaTupuna;
        }

        /// <summary>
        /// Check if any fields are not filled in for a tupuna
        /// Because we want to ensure at least one parents details are filled in
        /// </summary>
        /// <param name="tupuna"></param>
        /// <returns></returns>
        private bool ValidateTupuna(SaveTupunaResource tupuna)
        {
            foreach (var property in tupuna.GetType().GetProperties())
            {
                var val = property.GetValue(tupuna, null);

                if (val == null)
                {
                    return false;
                }

                if (string.IsNullOrEmpty(val.ToString()))
                {
                    return false;
                }
            }

            return true;
        }

        private bool ValidateParents(IEnumerable<SaveTupunaResource> NgaTupuna)
        {
            var mamaValid = true;
            var papaValid = true;

            foreach (var tupuna in NgaTupuna)
            {
                if (tupuna.Relationship.ToLower().Equals("mother"))
                {
                    mamaValid = ValidateTupuna(tupuna);
                }
                else if (tupuna.Relationship.ToLower().Equals("father"))
                {
                    papaValid = ValidateTupuna(tupuna);
                }
            }

            if (papaValid || mamaValid)
            {
                return true;
            }

            return false;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("FirstName,LastName,Gender,DOB,PlaceOfBirth,Occupation,SpecialtySkills,Address1,Address2,Address3,PostCode,Country,HomePhone,Mobile,Email,IsTeReoFirstLanguage,CanYouSpeakTeReo,TeReoProficiency,ReturnToRuatokiToLive,ReturnComment,Facebook,Twitter,Instagram,NgaMaraeIdList,NgaTupuna")] SaveTangataResource Member)
        {
            var parentsValid = ValidateParents(Member.NgaTupuna);
            var validTupuna = new List<SaveTupunaResource>();

            //parentsValid = false;
            if (!parentsValid)
            {
                ModelState.AddModelError("Member.NgaTupuna", "Please complete the details for 1 of your parents");
            }

            if (!ModelState.IsValid)
            {
                //Only persist valid
                foreach (var tupuna in Member.NgaTupuna)
                {
                    //Still show Mother and Father after invalid submission
                    if (tupuna.Relationship == "Mother" || tupuna.Relationship == "Father")
                    {
                        validTupuna.Add(tupuna);
                        continue;
                    }

                    if (!string.IsNullOrEmpty(tupuna.Name) || tupuna.Relationship == "Relationship")
                    {
                        validTupuna.Add(tupuna);
                    }
                }

                Member.NgaTupuna = validTupuna;
                var vm = new RegisterViewModel();
                var ngaMarae = await maraeClient.GetNgaMaraeAsync();
                var maraeGrouping = ngaMarae.GroupBy(x => x.Area);
                vm.Member = Member;

                vm.NgaMaraeGoup = maraeGrouping.OrderBy(x => x.Key);

                ModelState.AddModelError(string.Empty, "Error Creating Member");
                return View(vm);
            }

            //Only persist valid
            foreach (var tupuna in Member.NgaTupuna)
            {
                if (!string.IsNullOrEmpty(tupuna.Name) || tupuna.Relationship == "Relationship")
                {
                    validTupuna.Add(tupuna);
                }
            }

            Member.NgaTupuna = validTupuna;

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

        public IActionResult About()
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