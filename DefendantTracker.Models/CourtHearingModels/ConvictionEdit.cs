using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefendantTracker.Models.CourtHearingModels
{
    public class ConvictionEdit
    {
        public string HearingDesc { get; set; }
        public DateTime CourtDate { get; set; }
        public string CourtAddress { get; set; }
        public string CourtCity { get; set; }
        public string CourtCounty { get; set; }
        public string CourtState { get; set; }
        public int CourtZipcode { get; set; }
    }
}
