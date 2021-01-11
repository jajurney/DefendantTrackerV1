using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefendantTracker.Data
{
    public class Defendant
    {
        [Key]
        public int DefendantID { get; set; }
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string DFullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
            set { }
        }
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
        public bool Prosecuted { get; set; }
        public bool Arrested { get; set; }
    }
}
