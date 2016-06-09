using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace about.me.Models
{
    public class Contact_Profile
    {
        public Contact_Profile() { }

        [Key]
        public Int64 Contact_ProfileID { get; set; }
        
        public Int64 ProfileID { get; set; }
        [ForeignKey("ProfileID")]
        public virtual Profile Profile { get; set; }

        public string Direction { get; set; }

        public string Phone { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Url)]
        public string Website { get; set; }

        [DataType(DataType.Url)]
        public string Facebook { get; set; }

        [DataType(DataType.Url)]
        public string Twitter { get; set; }

        [DataType(DataType.Url)]
        public string  Linkedin { get; set; }

        //public virtual ICollection<Profile> Profile { get; set; }
    }
}