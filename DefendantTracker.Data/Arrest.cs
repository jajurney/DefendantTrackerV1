using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefendantTracker.Data
{
    public class Arrest
    {
        [Key]
        public int ArrestID { get; set; }
        [Required]
        public DateTime ArrestDate { get; set; }
        [Required]
        public string StreetName { get; set; }
        [Required]
        public string ArrestCity { get; set; }
        [Required]
        public string ArrestCounty { get; set; }
        [Required]
        public string ArrestState { get; set; }
        [Required]
        public int ArrestZipcode { get; set; }
        [Required]
        public string ArrestLocation
        {
            get
            {
                return StreetName + " " + ArrestCity + " " + ArrestCounty + " " + ArrestState + " " + ArrestZipcode;
            }
            set { }
        }
        public string ArrestDesc { get; set; }
     
        public int DefendantID { get; set; }
        [ForeignKey("DefendantID")]
        public virtual Defendant Defendant { get; set; }
    }
}
