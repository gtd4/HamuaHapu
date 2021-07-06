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
        public string Gender { get; set; }

        public string DOB { get; set; }
        public string PlaceOfBirth { get; set; }
        public string Occupation { get; set; }
        public string SalaryRange { get; set; }
        public string SpecialtySkills { get; set; }

        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
        public string HomePhone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public bool IsTeReoFirstLanguage { get; set; }
        public bool CanYouSpeakTeReo { get; set; }
        public string TeReoProficiency { get; set; }
        public string ReturnToRuatokiToLive { get; set; }
        public string ReturnComment { get; set; }

        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }

        public bool KeepMeNotified { get; set; }

        //public string FathersName { get; set; }
        //public string FathersPrimaryIwi { get; set; }
        //public string FathersPrimaryHapu { get; set; }
        //public string MothersName { get; set; }
        //public string MothersPrimaryIwi { get; set; }
        //public string MothersPrimaryHapu { get; set; }

        public Tangata Mother { get; set; }
        public int? MotherID { get; set; }
        public Tangata Father { get; set; }
        public int? FatherID { get; set; }

        public ICollection<Tangata> Children { get; set; } = new List<Tangata>();

        public ICollection<Marae> NgaMarae { get; set; } = new List<Marae>();
        public ICollection<Tupuna> NgaTupuna { get; set; } = new List<Tupuna>();

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string ModifiedBy { get; set; }
        public string IsActive { get; set; }
        //public int MaraeId { get; set; }

        //public bool? IsDeleted { get; set; }

        public Tangata()
        {
        }
    }
}