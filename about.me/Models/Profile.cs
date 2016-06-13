using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace about.me.Models
{
    public class Profile
    {
        //public Profile() { }

        [Key]
        public Int64 ProfileID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        
        public string Profesion { get; set; }

        public virtual Contact_Profile Contact { get; set; }

        public virtual ICollection<Education> Education { get; set; }

        public virtual ICollection<Experience> Experience { get; set; }

        public virtual Habilities Hability { get; set; }	  
    }
}