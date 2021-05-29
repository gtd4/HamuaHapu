using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HamuaHapuCommon.Resources
{
    public class TangataResource
    {
        public int TangataId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Gender { get; set; }

        public string DOB { get; set; }
        public string PlaceOfBirth { get; set; }
        public string Occupation { get; set; }
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
        public bool ReturnToRuatokiToLive { get; set; }
        public string ReturnComment { get; set; }

        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }
        public IEnumerable<TupunaResource> NgaTupuna { get; set; }
    }
}