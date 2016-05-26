using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace about.me.Models
{
    public class Contact_Profile
    {
        public Contact_Profile() { }

        public Int64 ID { get; set; }

        public Int64 ID_Profile { get; set; }

        public string Direction { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Website { get; set; }

        public string Facebook { get; set; }

        public string Twitter { get; set; }

        public string  Linkedin { get; set; }

        public ICollection<Profile> Profiles { get; set; }
    }
}