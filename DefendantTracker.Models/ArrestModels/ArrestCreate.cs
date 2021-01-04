using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefendantTracker.Models.ArrestModels
{
    public class ArrestCreate
    {
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
        public string ArrestDesc { get; set; }
        public int DefendantID { get; set; }

    }
}
