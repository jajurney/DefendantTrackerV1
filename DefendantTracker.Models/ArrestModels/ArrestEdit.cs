﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefendantTracker.Models.ArrestModels
{
    public class ArrestEdit
    {
        public DateTime ArrestDate { get; set; }
        public string StreetName { get; set; }
        public string ArrestCity { get; set; }
        public string ArrestCounty { get; set; }
        public string ArrestState { get; set; }
        public int ArrestZipcode { get; set; }
        public string ArrestDesc { get; set; }
        public int DefendantID { get; set; }
        public int OfficerID { get; set; }

    }
}
