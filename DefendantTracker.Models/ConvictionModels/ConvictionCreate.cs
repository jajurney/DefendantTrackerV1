using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefendantTracker.Models.ConvictionModels
{
    public class ConvictionCreate
    {
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
        public DateTime DateOfConviction { get; set; }
        [Required]
        public ConvictionSeverity ConvictionSeverity { get; set; }
    }
    public enum ConvictionSeverity
    {
        LevelOne,
        LevelTwo,
        LevelThree,
        LevelFour,
        LevelFive
    }
}
