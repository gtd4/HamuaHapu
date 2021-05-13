using HamuaHapuCommon.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HamuaHapuRegistration.ApiClients.Interfaces
{
    public interface INgaMaraeClient
    {
        static readonly HttpClient client = new HttpClient();

        Task<IEnumerable<MaraeResource>> GetNgaMaraeAsync(string url = "");

        Task<MaraeResource> GetMaraeByIdAsync(int id);

        Task<MaraeResource> CreateAsync(SaveMaraeResource ngaMarae);

        Task<MaraeResource> EditAsync(int id, MaraeResource ngaMarae);
    }
}