using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HamuaRegistrationApi.DAL.Models
{
    public class Marae
    {
        public int MaraeId { get; set; }
        public string Area { get; set; }

        public string Name { get; set; }
        public string Hapu { get; set; }

        public ICollection<Tangata> NgaTangata { get; set; } = new List<Tangata>();

        //public int TangataId { get; set; }

        //public bool? IsDeleted { get; set; }

        public Marae()
        {
        }
    }
}