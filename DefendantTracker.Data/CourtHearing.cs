using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefendantTracker.Data
{
    public class CourtHearing
    {
        [Key]
        public int CourtHearingID { get; set; }
        [Required]
        public string HearingDesc { get; set; }
        [Required]
        public DateTime CourtDate { get; set; }
        [Required]
        public string CourtAddress { get; set; }
        [Required]
        public string CourtCity { get; set; }
        [Required]
        public string CourtCounty { get; set; }
        [Required]
        public string CourtState { get; set; }
        [Required]
        public int CourtZipcode { get; set; }
        [Required]
        public string FullLocation
        {
            get
            {
                return CourtAddress + " " + CourtCity + " " + CourtCounty + " " + CourtState + " " + CourtZipcode;
            }
            set { }
        }
        // [ForeignKey(nameof(StateAttorneyID))]
        // public virtual StateAttorney StateAttorney { get; set; }
        // [ForeignKey(nameof(DefenseAttorneyID))]
        // public virtual DefenseAttorney DefenseAttorney { get; set; }
        // [ForeignKey(nameof(OfficerID))]
        // public virtual Officer Officer { get; set; }
        // [ForeignKey(nameof(DefendantID))]
        // public virtual Defendant Defendant { get; set; }
        // [ForeignKey(nameof(ArrestID))]
        // public virtual Arrest Arrest { get; set; }
    }
}
