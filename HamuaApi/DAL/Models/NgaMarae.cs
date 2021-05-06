using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HamuaRegistrationApi.DAL.Models
{
    public class NgaMarae
    {
        public int ID { get; set; }
        public string Area { get; set; }

        public string Marae { get; set; }
        public string Hapu { get; set; }

        public NgaMarae()
        {
        }
    }
}