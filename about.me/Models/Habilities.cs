using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace about.me.Models
{
    public class Habilities
    {
        //public Habilities() { }

        [Key]
        public Int64 HabilitiesID { get; set; }

        public Int64 ProfileID { get; set; }
        [ForeignKey("ProfileID")]
        public virtual Profile Profile { get; set; }

        public string NameHability { get; set; }

        [Range(0, 100, ErrorMessage = "Seleccione un valor de 0 a 100")]
        public int Porcentage { get; set; }

        public virtual ICollection<Profile> Profiles { get; set; }
    }
}