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

namespace HamuaHapuRegistration.Controllers
{
    public class NgaMaraeController : Controller
    {
        private IConfiguration config;
        private string apiBaseUrl;

        public NgaMaraeController(IConfiguration _config)
        {
            config = _config;
            apiBaseUrl = config.GetValue<string>("hamuaApiBaseUrl");
        }

        // GET: NgaMarae
        public async Task<IActionResult> Index(string orderby = "", string searchString = "", bool includeTangata = false)
        {
            using (HttpClient client = new HttpClient())
            {
                //StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                string endpoint = apiBaseUrl + "/ngamarae";
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

                using (var response = await client.GetAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var stringResult = await response.Content.ReadAsStringAsync();
                        var ngaMarae = JsonConvert.DeserializeObject<IEnumerable<MaraeResource>>(stringResult);
                        return View(ngaMarae);
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

        // GET: NgaMarae/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            using (HttpClient client = new HttpClient())
            {
                //StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                string endpoint = $"{apiBaseUrl}/ngamarae/{id}";

                using (var response = await client.GetAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var stringResult = await response.Content.ReadAsStringAsync();
                        var marae = JsonConvert.DeserializeObject<MaraeResource>(stringResult);
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
        public async Task<IActionResult> Create([Bind("Area,Name,Hapu")] NgaMarae ngaMarae)
        {
            return View();
        }

        // GET: NgaMarae/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            using (HttpClient client = new HttpClient())
            {
                //StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                string endpoint = $"{apiBaseUrl}/ngamarae/{id}";

                using (var response = await client.GetAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var stringResult = await response.Content.ReadAsStringAsync();
                        var marae = JsonConvert.DeserializeObject<MaraeResource>(stringResult);
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

        // POST: NgaMarae/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaraeId,Area,Name,Hapu")] MaraeResource ngaMarae)
        {
            using (HttpClient client = new HttpClient())
            {
                //StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                string endpoint = $"{apiBaseUrl}/ngamarae/{id}";
                var jsonString = JsonConvert.SerializeObject(ngaMarae);

                var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                using (var response = await client.PutAsync(endpoint, httpContent))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var stringResult = await response.Content.ReadAsStringAsync();
                        var marae = JsonConvert.DeserializeObject<MaraeResource>(stringResult);
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
    }
}