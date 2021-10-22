﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HamuaHapuCommon.Resources
{
    public class SaveTangataResource
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        public string Gender { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DOB { get; set; }

        [Required]
        [Display(Name = "Place of Birth")]
        public string PlaceOfBirth { get; set; }

        [Required]
        public string Occupation { get; set; }

        [Display(Name = "Salary Range")]
        public string SalaryRange { get; set; }

        [Display(Name = "Specialty Skills")]
        public string SpecialtySkills { get; set; }

        [Required]
        public string Address1 { get; set; }

        public string Address2 { get; set; }

        [Required]
        public string Address3 { get; set; }

        [Required]
        public string PostCode { get; set; }

        [Required]
        public string Country { get; set; }

        [Display(Name = "Home Phone")]
        public string HomePhone { get; set; }

        public string Mobile { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        public bool IsTeReoFirstLanguage { get; set; }

        [Required]
        public bool CanYouSpeakTeReo { get; set; }

        public string TeReoProficiency { get; set; }

        [Required]
        public string ReturnToRuatokiToLive { get; set; }

        public string ReturnComment { get; set; }

        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }

        [Required]
        public bool KeepMeNotified { get; set; }

        [Required, MinLength(1, ErrorMessage = "Please pick at least 1 marae")]
        public IEnumerable<int> NgaMaraeIdList { get; set; } = new List<int>();

        [Required, MinLength(1, ErrorMessage = "Please Fill in the details for at least 1 Tupuna")]
        public IEnumerable<SaveTupunaResource> NgaTupuna { get; set; } = new List<SaveTupunaResource>();

        public string ModifiedBy { get; set; }

        public string HighestEducation { get; set; }
        public bool OwnHome { get; set; }
        public int NumberInHome { get; set; }
    }
}