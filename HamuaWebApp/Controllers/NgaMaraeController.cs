using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HamuaHapuRegistration.Models;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using System.Text;
using Newtonsoft.Json;
using System.Collections.Generic;
using HamuaHapuCommon.Resources;
using System.Linq;
using System;
using HamuaHapuRegistration.ApiClients.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace HamuaHapuRegistration.Controllers
{
    [Authorize]
    public class NgaMaraeController : Controller
    {
        private IConfiguration config;
        private string apiBaseUrl;
        private INgaMaraeClient ngaMaraeClient;

        public NgaMaraeController(IConfiguration _config, INgaMaraeClient client)
        {
            config = _config;
            apiBaseUrl = config.GetValue<string>("hamuaApiBaseUrl") + "/ngamarae";
            ngaMaraeClient = client;
        }

        // GET: NgaMarae
        public async Task<IActionResult> Index(string orderby = "", string searchString = "", bool includeTangata = false)
        {
            ViewData["MaraeSortParm"] = String.IsNullOrEmpty(orderby) ? "marae_desc" : "";
            ViewData["HapuSortParm"] = orderby == "hapu" ? "hapu_desc" : "hapu";
            ViewData["AreaSortParm"] = orderby == "area" ? "area_desc" : "area";

            var url = SetQueryParams(orderby, searchString, includeTangata, apiBaseUrl);

            var ngaMarae = await ngaMaraeClient.GetNgaMaraeAsync(url);

            //StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

            if (ngaMarae.Any())
            {
                return View(ngaMarae);
            }
            else
            {
                //ModelState.Clear();
                //ModelState.AddModelError(string.Empty, "Error Getting Marae");
                return NotFound();
            }
        }

        // GET: NgaMarae/Details/5
        public async Task<IActionResult> Details(int? id, string success_msg = "")
        {
            if (id == null)
            {
                return NotFound();
            }

            if (success_msg.ToLower().Equals("created") || success_msg.ToLower().Equals("updated"))
            {
                success_msg = "";
            }

            ViewData["Created"] = success_msg;

            //StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            string endpoint = $"{apiBaseUrl}/{id}";

            var marae = await ngaMaraeClient.GetMaraeByIdAsync((int)id);

            if (marae == null)
            {
                ModelState.Clear();
                ModelState.AddModelError(string.Empty, "Error Getting Marae");
                return NotFound();
            }
            else
            {
                return View(marae);
            }
        }

        // GET: NgaMarae/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NgaMarae/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Area,Name,Hapu")] SaveMaraeResource ngaMarae)
        {
            if (!ModelState.IsValid)
            {
            }

            var marae = await ngaMaraeClient.CreateAsync(ngaMarae);

            if (marae == null)
            {
                ModelState.Clear();
                ModelState.AddModelError(string.Empty, "Error Creating Marae");
                return View(ngaMarae);
            }
            else
            {
                return RedirectToAction(nameof(Details), new { id = marae.MaraeId, success_msg = "Created" });
            }
        }

        // GET: NgaMarae/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marae = await ngaMaraeClient.GetMaraeByIdAsync((int)id);

            if (marae == null)
            {
                ModelState.Clear();
                ModelState.AddModelError(string.Empty, "Error Getting Marae");
                return NotFound();
            }
            else
            {
                return View(marae);
            }
        }

        // POST: NgaMarae/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaraeId,Area,Name,Hapu")] MaraeResource ngaMarae)
        {
            var marae = await ngaMaraeClient.EditAsync(id, ngaMarae);

            if (marae == null)
            {
                ModelState.Clear();
                ModelState.AddModelError(string.Empty, "Error Getting Marae");
                return View(ngaMarae);
            }
            else
            {
                return RedirectToAction(nameof(Details), new { id = marae.MaraeId, success_msg = "Updated" });
            }
        }

        // GET: NgaMarae/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            return View();
        }

        // POST: NgaMarae/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            return View();
        }

        //ToDo: Where should this live?
        private static string SetQueryParams(string orderby, string searchString, bool includeTangata, string endpoint)
        {
            var queryString = new List<string>();

            if (!string.IsNullOrEmpty(orderby))
            {
                queryString.Add($"orderby={orderby}");
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                queryString.Add($"searchString={searchString}");
            }

            if (includeTangata)
            {
                queryString.Add($"includeTangata={includeTangata}");
            }
            var sb = new StringBuilder();
            var count = 0;
            if (queryString.Any())
            {
                foreach (var queryParam in queryString)
                {
                    if (count == 0)
                    {
                        sb.Append($"?{queryParam}");
                    }
                    else
                    {
                        sb.Append($"&{queryParam}");
                    }
                }
                endpoint += sb.ToString();
            }

            return endpoint;
        }
    }
}