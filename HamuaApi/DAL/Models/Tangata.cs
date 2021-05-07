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

        public int ParentId { get; set; }

        public ICollection<Marae> NgaMarae { get; set; } = new List<Marae>();
        //public int MaraeId { get; set; }

        //public bool? IsDeleted { get; set; }

        public Tangata()
        {
        }
    }
}