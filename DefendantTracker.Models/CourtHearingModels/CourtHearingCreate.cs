﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefendantTracker.Models.CourtHearingModels
{
    public class CourtHearingCreate
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
        public int StateAttorneyID { get; set; }
        [Required]
        public int DefenseAttorneyID { get; set; }
        [Required]
        public int OfficerID { get; set; }
        [Required]
        public int DefendantID { get; set; }
        [Required]
        public int ArrestID { get; set; }

    }
}
