using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HamuaRegistrationApi.DAL.Models
{
    public class Tangata
    {
        public int TangataId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IEnumerable<Marae> NgaMarae { get; set; }

        public int MaraeId { get; set; }

        //public bool? IsDeleted { get; set; }

        public Tangata()
        {
        }
    }
}