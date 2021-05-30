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

namespace HamuaHapuRegistration.Controllers
{
    [Authorize]
    public class NgaTangataController : Controller
    {
        private readonly HamuaHapuRegistrationContext _context;

        private IConfiguration config;
        private string apiBaseUrl;

        public NgaTangataController(HamuaHapuRegistrationContext context, IConfiguration _config)
        {
            _context = context;
            config = _config;
            apiBaseUrl = config.GetValue<string>("hamuaApiBaseUrl") + "/ngatangata";
        }

        // GET: HapuMembers
        public async Task<IActionResult> Index()
        {
            using (HttpClient client = new HttpClient())
            {
                //StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

                var endpoint = apiBaseUrl;//SetQueryParams(orderby, searchString, includeTangata, apiBaseUrl);

                using (var response = await client.GetAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var stringResult = await response.Content.ReadAsStringAsync();
                        var ngaTangata = JsonConvert.DeserializeObject<IEnumerable<TangataResource>>(stringResult);
                        return View(ngaTangata);
                    }
                    else
                    {
                        ModelState.Clear();
                        ModelState.AddModelError(string.Empty, "Error Getting Nga Tangata");
                        return View();
                    }
                }
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

            using (HttpClient client = new HttpClient())
            {
                //StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                string endpoint = $"{apiBaseUrl}/{id}";

                using (var response = await client.GetAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var stringResult = await response.Content.ReadAsStringAsync();
                        var marae = JsonConvert.DeserializeObject<TangataResource>(stringResult);
                        return View(marae);
                    }
                    else
                    {
                        ModelState.Clear();
                        ModelState.AddModelError(string.Empty, "Error Getting Marae");
                        return View();
                    }
                }
            }
        }

        // GET: HapuMembers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HapuMembers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,Gender,DOB,PlaceOfBirth,Occupation,SpecialtySkills,Address1,Address2,Address3,PostCode,Country,HomePhone,Mobile,Email,IsTeReoFirstLanguage,CanYouSpeakTeReo,TeReoProficiency,ReturnToRuatokiToLive,ReturnComment,Facebook,Twitter,Instagram")] SaveTangataResource hapuMember)
        {
            using (HttpClient client = new HttpClient())
            {
                var jsonString = JsonConvert.SerializeObject(hapuMember);

                var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                using (var response = await client.PostAsync(apiBaseUrl, httpContent))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.Created)
                    {
                        var stringResult = await response.Content.ReadAsStringAsync();
                        var tangata = JsonConvert.DeserializeObject<TangataResource>(stringResult);
                        return RedirectToAction(nameof(Details), new { id = tangata.TangataId, success_msg = "Created" });
                    }
                    else
                    {
                        ModelState.Clear();
                        ModelState.AddModelError(string.Empty, "Error Creating Marae");
                        return View(hapuMember);
                    }
                }
            }
        }

        // GET: HapuMembers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            using (HttpClient client = new HttpClient())
            {
                //StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                string endpoint = $"{apiBaseUrl}/{id}";

                using (var response = await client.GetAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var stringResult = await response.Content.ReadAsStringAsync();
                        var tangata = JsonConvert.DeserializeObject<TangataResource>(stringResult);
                        return View(tangata);
                    }
                    else
                    {
                        ModelState.Clear();
                        ModelState.AddModelError(string.Empty, "Error Getting Marae");
                        return View();
                    }
                }
            }
        }

        // POST: HapuMembers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,LastName,Gender,DOB,PlaceOfBirth,Occupation,SpecialtySkills,Address1,Address2,Address3,PostCode,Country,HomePhone,Mobile,Email,IsTeReoFirstLanguage,CanYouSpeakTeReo,TeReoProficiency,ReturnToRuatokiToLive,ReturnComment,Facebook,Twitter,Instagram")] TangataResource hapuMember)
        {
            using (HttpClient client = new HttpClient())
            {
                //StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                string endpoint = $"{apiBaseUrl}/{id}";
                var jsonString = JsonConvert.SerializeObject(hapuMember);

                var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                using (var response = await client.PutAsync(endpoint, httpContent))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var stringResult = await response.Content.ReadAsStringAsync();
                        var tangata = JsonConvert.DeserializeObject<TangataResource>(stringResult);
                        return RedirectToAction(nameof(Details), new { id = tangata.TangataId, success_msg = "Updated" });
                    }
                    else
                    {
                        ModelState.Clear();
                        ModelState.AddModelError(string.Empty, "Error Getting Marae");
                        return View(hapuMember);
                    }
                }
            }
        }

        // GET: HapuMembers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hapuMember = await _context.HapuMember
                .FirstOrDefaultAsync(m => m.ID == id);
            if (hapuMember == null)
            {
                return NotFound();
            }

            return View(hapuMember);
        }

        // POST: HapuMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hapuMember = await _context.HapuMember.FindAsync(id);
            _context.HapuMember.Remove(hapuMember);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HapuMemberExists(int id)
        {
            return _context.HapuMember.Any(e => e.ID == id);
        }
    }
}