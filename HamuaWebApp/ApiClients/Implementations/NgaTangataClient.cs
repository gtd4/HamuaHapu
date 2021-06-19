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
    public class NgaTangataClient : INgaTangataClient
    {
        private IConfiguration config;
        private string apiBaseUrl;
        private static readonly HttpClient client = new HttpClient();

        public NgaTangataClient(IConfiguration configuration)
        {
            config = configuration;
            apiBaseUrl = config.GetValue<string>("hamuaApiBaseUrl") + "/ngatangata";
        }

        //public Task<TangataResource> CreateAsync(SaveTangataResource ngaMarae)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<TangataResource> EditAsync(int id, TangataResource ngaTangata)
        {
            //StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            string endpoint = $"{apiBaseUrl}/{id}";
            var jsonString = JsonConvert.SerializeObject(ngaTangata);

            var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            using (var response = await client.PutAsync(endpoint, httpContent))
            {
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var stringResult = await response.Content.ReadAsStringAsync();
                    var tangata = JsonConvert.DeserializeObject<TangataResource>(stringResult);
                    return tangata;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<TangataResource> GetTangataByIdAsync(int id)
        {
            string endpoint = $"{apiBaseUrl}/{id}";

            using (var response = await client.GetAsync(endpoint))
            {
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var stringResult = await response.Content.ReadAsStringAsync();
                    var tangata = JsonConvert.DeserializeObject<TangataResource>(stringResult);
                    return tangata;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<IEnumerable<TangataResource>> GetNgaTangataAsync(string url = "")
        {
            if (string.IsNullOrEmpty(url))
            {
                url = apiBaseUrl;
            }

            using (var response = await client.GetAsync(url))
            {
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var stringResult = await response.Content.ReadAsStringAsync();
                    var ngaTangata = JsonConvert.DeserializeObject<IEnumerable<TangataResource>>(stringResult);
                    return ngaTangata;
                }
                else
                {
                    return new List<TangataResource>();
                }
            }
        }

        public async Task<IEnumerable<IGrouping<string, TangataResource>>> GetTangataGender()
        {
            string endpoint = $"{apiBaseUrl}/gender";

            using (var response = await client.GetAsync(endpoint))
            {
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var stringResult = await response.Content.ReadAsStringAsync();
                    var ngaTangata = JsonConvert.DeserializeObject<IEnumerable<IGrouping<string, TangataResource>>>(stringResult);
                    return ngaTangata;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<IEnumerable<IGrouping<string, TangataResource>>> GetTangataReoProficiency()
        {
            string endpoint = $"{apiBaseUrl}/reo-proficiency";

            using (var response = await client.GetAsync(endpoint))
            {
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var stringResult = await response.Content.ReadAsStringAsync();
                    var ngaTangata = JsonConvert.DeserializeObject<IEnumerable<IGrouping<string, TangataResource>>>(stringResult);
                    return ngaTangata;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<IEnumerable<IGrouping<string, TangataResource>>> GetTangataResidenceCountry()
        {
            string endpoint = $"{apiBaseUrl}/residence/country";

            using (var response = await client.GetAsync(endpoint))
            {
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var stringResult = await response.Content.ReadAsStringAsync();
                    var ngaTangata = JsonConvert.DeserializeObject<IEnumerable<IGrouping<string, TangataResource>>>(stringResult);
                    return ngaTangata;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}