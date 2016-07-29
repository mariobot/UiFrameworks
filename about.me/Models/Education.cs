using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace about.me.Models
{
    public class Education
    {
        //public Education() { }

        [Key]
        public Int64 EducationID { get; set; }

        public Int64 ProfileID { get; set; }
        [ForeignKey("ProfileID")]
        public virtual Profile Profile { get; set; }        

        public string NameCareer { get; set; }

        public string NameUniversity { get; set; }

        public string DateStart { get; set; }

        public string DateEnd { get; set; }

        public string ShortDescription { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Profile> Profiles { get; set; }
    }
}