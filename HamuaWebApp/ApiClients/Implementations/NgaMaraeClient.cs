using HamuaHapuCommon.Resources;
using HamuaHapuRegistration.ApiClients.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HamuaHapuRegistration.ApiClients.Implementations
{
    public class NgaMaraeClient : INgaMaraeClient
    {
        private IConfiguration config;
        private string apiBaseUrl;
        private static readonly HttpClient client = new HttpClient();

        public NgaMaraeClient(IConfiguration configuration)
        {
            config = configuration;
            apiBaseUrl = config.GetValue<string>("hamuaApiBaseUrl") + "/ngamarae";
        }

        public async Task<IEnumerable<MaraeResource>> GetNgaMaraeAsync(string url = "")
        {
            //StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

            //var endpoint = SetQueryParams(orderby, searchString, includeTangata, apiBaseUrl);

            if (string.IsNullOrEmpty(url))
            {
                url = apiBaseUrl;
            }

            using (var response = await client.GetAsync(url))
            {
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var stringResult = await response.Content.ReadAsStringAsync();
                    var ngaMarae = JsonConvert.DeserializeObject<IEnumerable<MaraeResource>>(stringResult);
                    return ngaMarae;
                }
                else
                {
                    return new List<MaraeResource>();
                }
            }
        }

        public async Task<MaraeResource> GetMaraeByIdAsync(int id)
        {
            //StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            string endpoint = $"{apiBaseUrl}/{id}";

            using (var response = await client.GetAsync(endpoint))
            {
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var stringResult = await response.Content.ReadAsStringAsync();
                    var marae = JsonConvert.DeserializeObject<MaraeResource>(stringResult);
                    return marae;
                }
                else
                {
                    //ModelState.Clear();
                    //ModelState.AddModelError(string.Empty, "Error Getting Marae");
                    return null;
                }
            }
        }

        public async Task<MaraeResource> CreateAsync(SaveMaraeResource ngaMarae)
        {
            var jsonString = JsonConvert.SerializeObject(ngaMarae);

            var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            using (var response = await client.PostAsync(apiBaseUrl, httpContent))
            {
                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    var stringResult = await response.Content.ReadAsStringAsync();
                    var marae = JsonConvert.DeserializeObject<MaraeResource>(stringResult);
                    return marae;
                }
                else
                {
                    //ModelState.Clear();
                    //ModelState.AddModelError(string.Empty, "Error Creating Marae");
                    return null;
                }
            }
        }

        public async Task<MaraeResource> EditAsync(int id, MaraeResource ngaMarae)
        {
            //StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            string endpoint = $"{apiBaseUrl}/{id}";
            var jsonString = JsonConvert.SerializeObject(ngaMarae);

            var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            using (var response = await client.PutAsync(endpoint, httpContent))
            {
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var stringResult = await response.Content.ReadAsStringAsync();
                    var marae = JsonConvert.DeserializeObject<MaraeResource>(stringResult);
                    return marae;
                }
                else
                {
                    //ModelState.Clear();
                    //ModelState.AddModelError(string.Empty, "Error Getting Marae");
                    return null;
                }
            }
        }
    }
}