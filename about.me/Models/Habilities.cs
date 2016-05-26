using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace about.me.Models
{
    public class Habilities
    {
        public Habilities() { }

        public Int64 ID { get; set; }

        public Int64 ID_Profile { get; set; }

        public string Name { get; set; }

        public int Porcentage { get; set; }

        public ICollection<Profile> Profiles { get; set; }
    }
}