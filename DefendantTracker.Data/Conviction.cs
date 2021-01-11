using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefendantTracker.Data
{
    public enum ConvictionSeverity
    {
        LevelOne,
        LevelTwo,
        LevelThree,
        LevelFour,
        LevelFive
    }
    public class Conviction
    {
        [Key]
        public int ConvicID { get; set; }
        [Required]
        public string StreetAddress { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string County { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public int Zipcode { get; set; }
        [Required]
        public string FullLocation
        {
            get
            {
                return StreetAddress + " " + City + " " + County + " " + State + " " + Zipcode;
            }
            set { }
        }
        public DateTime DateOfConviction { get; set; }
        [Required]
        public ConvictionSeverity ConvictionSeverity { get; set; }
        public int ArrestID { get; set; }
        [ForeignKey("ArrestID")]
        public virtual Arrest Arrests { get; set; }
        public int DefendantID { get; set; }
        [ForeignKey("DefendantID")]
        public virtual Defendant Defendants { get; set; }
        public int CourtHearingID { get; set; }
        [ForeignKey("CourtHearingID")]
        public virtual CourtHearing CourtHearings { get; set; }
    }
   
}
