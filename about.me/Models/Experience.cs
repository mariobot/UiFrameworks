using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace about.me.Models
{
    public class Experience
    {
        public Experience() { }

        public Int64 ID { get; set; }

        public Int64 ID_Profile { get; set; }

        public string NameCharge { get; set; }

        public string Company { get; set; }

        public string DateStart { get; set; }

        public string DateEnd { get; set; }

        public string ShortDescription { get; set; }

        public string Description { get; set; }

        public ICollection<Profile> Profiles { get; set; }
    }
}