using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HamuaRegistrationApi.DAL.Models
{
    public class Tupuna
    {
        public int TupunaId { get; set; }
        public Tangata Uri { get; set; }
        public string Name { get; set; }
        public string PrimaryIwi { get; set; }
        public string PrimaryHapu { get; set; }
        public string Relationship { get; set; }
    }
}