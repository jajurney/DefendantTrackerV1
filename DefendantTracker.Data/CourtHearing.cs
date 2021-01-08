using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public int StateAttorneyID { get; set; }
        [ForeignKey("StateAttorneyID")]
        public virtual StateAttorney StateAttorney { get; set; }
        public int DefenseAttorneyID { get; set; }
        [ForeignKey("DefenseAttorneyID")]
        public virtual DefenseAttorney DefenseAttorney { get; set; }
        public int OfficerID { get; set; }
        [ForeignKey("OfficerID")]
        public virtual Officer Officer { get; set; }
        public int DefendantID { get; set; }
        [ForeignKey("DefendantID")]
        public virtual Defendant Defendant { get; set; }
        public int ArrestID { get; set; }
        [ForeignKey("ArrestID")]
        public virtual Arrest Arrest { get; set; }
    }
}
