using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefendantTracker.Models.CourtHearingModels
{
    public class CourtHearingEdit
    {
        public int CourtHearingID { get; set; }
        public string HearingDesc { get; set; }
        public DateTime CourtDate { get; set; }
        public string CourtAddress { get; set; }
        public string CourtCity { get; set; }
        public string CourtCounty { get; set; }
        public string CourtState { get; set; }
        public int CourtZipcode { get; set; }
        public int StateAttorneyID { get; set; }
        public int DefenseAttorneyID { get; set; }
        public int OfficerID { get; set; }
        public int DefendantID { get; set; }
        public int ArrestID { get; set; }

    }
}
