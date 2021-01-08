using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefendantTracker.Models.DefendantModels
{
    public class DefendantCreate
    {
        public int DefendantID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
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
        public bool Prosecuted { get; set; }
        public bool Arrested { get; set; }
        //public int CourtHearingID { get; set; }
        //public int ConvictionID { get; set; }

    }
}
