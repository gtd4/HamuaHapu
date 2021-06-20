using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HamuaHapuRegistration.Data;
using HamuaHapuRegistration.Models;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using Newtonsoft.Json;
using HamuaHapuCommon.Resources;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using HamuaHapuRegistration.ApiClients.Interfaces;
using HamuaHapuRegistration.ViewModels;

namespace HamuaHapuRegistration.Controllers
{
    //ToDo: Uncomment this when going to production
    //[Authorize]
    [AllowAnonymous]
    public class NgaTangataController : Controller
    {
        //private readonly HamuaHapuRegistrationContext _context;

        private IConfiguration config;
        private string apiBaseUrl;
        private INgaTangataClient ngaTangataClient;

        public NgaTangataController(IConfiguration _config, INgaTangataClient client)
        {
            //_context = context;
            config = _config;
            apiBaseUrl = config.GetValue<string>("hamuaApiBaseUrl") + "/ngatangata";
            ngaTangataClient = client;
        }

        // GET: HapuMembers
        public async Task<IActionResult> Index()
        {
            var ngaTangata = await ngaTangataClient.GetNgaTangataAsync();

            //StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

            if (ngaTangata.Any())
            {
                return View(ngaTangata);
            }
            else
            {
                //ModelState.Clear();
                //ModelState.AddModelError(string.Empty, "Error Getting Marae");
                return NotFound();
            }
        }

        // GET: HapuMembers/Details/5
        public async Task<IActionResult> Details(int? id, string success_msg = "")
        {
            if (success_msg.ToLower().Equals("created") || success_msg.ToLower().Equals("updated"))
            {
                success_msg = "";
            }

            ViewData["Created"] = success_msg;

            var tangata = await ngaTangataClient.GetTangataByIdAsync((int)id);

            if (tangata == null)
            {
                ModelState.Clear();
                ModelState.AddModelError(string.Empty, "Error Getting Tangata");
                return NotFound();
            }
            else
            {
                return View(tangata);
            }
        }

        // GET: HapuMembers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tangata = await ngaTangataClient.GetTangataByIdAsync((int)id);

            if (tangata == null)
            {
                ModelState.Clear();
                ModelState.AddModelError(string.Empty, "Error Getting Tangata");
                return NotFound();
            }
            else
            {
                return View(tangata);
            }
        }

        // POST: HapuMembers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,LastName,Gender,DOB,PlaceOfBirth,Occupation,SpecialtySkills,Address1,Address2,Address3,PostCode,Country,HomePhone,Mobile,Email,IsTeReoFirstLanguage,CanYouSpeakTeReo,TeReoProficiency,ReturnToRuatokiToLive,ReturnComment,Facebook,Twitter,Instagram")] TangataResource hapuMember)
        {
            var tangata = await ngaTangataClient.EditAsync(id, hapuMember);

            if (tangata == null)
            {
                ModelState.Clear();
                ModelState.AddModelError(string.Empty, "Error Getting Tangata");
                return View(tangata);
            }
            else
            {
                return RedirectToAction(nameof(Details), new { id = tangata.TangataId, success_msg = "Updated" });
            }
        }

        public async Task<IActionResult> Stats()
        {
            List<ChartDataViewModel> chartDataList = new List<ChartDataViewModel>();

            var tangata = await ngaTangataClient.GetNgaTangataAsync();
            var genderGrouping = tangata.GroupBy(x => x.Gender);
            var countryGrouping = tangata.GroupBy(x => x.Country);
            var reoGrouping = tangata.GroupBy(x => x.TeReoProficiency);

            var genderChartData = new ChartDataViewModel();
            var countryChartData = new ChartDataViewModel();
            var reoChartData = new ChartDataViewModel();

            PopulateChartData(genderGrouping, genderChartData, "Gender");
            PopulateChartData(countryGrouping, countryChartData, "Country");
            PopulateChartData(reoGrouping, reoChartData, "Te Reo Proficiency");

            chartDataList.Add(reoChartData);
            chartDataList.Add(countryChartData);
            chartDataList.Add(genderChartData);

            return View("ChartData", chartDataList);
        }

        public async Task<IActionResult> GroupByGender()
        {
            var tangata = await ngaTangataClient.GetNgaTangataAsync();
            var tangataGrouping = tangata.GroupBy(x => x.Gender);

            var vm = new ChartDataViewModel();

            if (tangataGrouping == null)
            {
                ModelState.Clear();
                ModelState.AddModelError(string.Empty, "Error Getting Tangata");
                return View("ChartData", vm);
            }
            else
            {
                PopulateChartData(tangataGrouping, vm, "Gender");
                return View("ChartData", vm);
            }
        }

        private static void PopulateChartData(IEnumerable<IGrouping<string, TangataResource>> tangataGrouping, ChartDataViewModel vm, string title)
        {
            vm.Title = title;
            vm.Tangata = tangataGrouping;

            foreach (var group in tangataGrouping)
            {
                vm.ChartData.Add(group.Key, group.Count());
            }
        }

        public async Task<IActionResult> GroupByCountry()
        {
            var tangata = await ngaTangataClient.GetNgaTangataAsync();
            var tangataGrouping = tangata.GroupBy(x => x.Country);

            var vm = new ChartDataViewModel();

            if (tangataGrouping == null)
            {
                ModelState.Clear();
                ModelState.AddModelError(string.Empty, "Error Getting Tangata");
                return View("ChartData", vm);
            }
            else
            {
                vm.Title = "Country";
                vm.Tangata = tangataGrouping;

                foreach (var group in tangataGrouping)
                {
                    vm.ChartData.Add(group.Key, group.Count());
                }
                return View("ChartData", vm);
            }
        }

        public async Task<IActionResult> GroupByReoProficiency()
        {
            var tangata = await ngaTangataClient.GetNgaTangataAsync();
            var tangataGrouping = tangata.GroupBy(x => x.TeReoProficiency);

            var vm = new ChartDataViewModel();

            if (tangataGrouping == null)
            {
                ModelState.Clear();
                ModelState.AddModelError(string.Empty, "Error Getting Tangata");
                return View("ChartData", vm);
            }
            else
            {
                vm.Title = "Reo Proficiency";
                vm.Tangata = tangataGrouping;

                foreach (var group in tangataGrouping)
                {
                    var key = group.Key;
                    var count = group.Count();

                    if (string.IsNullOrEmpty(key))
                    {
                        key = "Non Te Reo Speaker";
                    }
                    vm.ChartData.Add(key, count);
                }

                return View("ChartData", vm);
            }
        }

        //// GET: HapuMembers/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    //if (id == null)
        //    //{
        //    //    return NotFound();
        //    //}

        //    //var hapuMember = await _context.HapuMember
        //    //    .FirstOrDefaultAsync(m => m.ID == id);
        //    //if (hapuMember == null)
        //    //{
        //    //    return NotFound();
        //    //}

        //    //return View(hapuMember);
        //}

        //// POST: HapuMembers/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var hapuMember = await _context.HapuMember.FindAsync(id);
        //    _context.HapuMember.Remove(hapuMember);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool HapuMemberExists(int id)
        //{
        //    return _context.HapuMember.Any(e => e.ID == id);
        //}
    }
}