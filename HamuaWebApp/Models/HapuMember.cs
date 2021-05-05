using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HamuaHapuRegistration.Models
{
    public class HapuMember
    {
        public int ID { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required]
        public string Surname { get; set; }

        //public DateTime DOB { get; set; }
        [Required]
        public string Birthplace { get; set; }

        public string Occupation { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        public string HomePhone { get; set; }

        [Required]
        public string Mobile { get; set; }

        public string Street { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
    }
}