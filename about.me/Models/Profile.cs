using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace about.me.Models
{
    public class Profile
    {
        public Profile() { }

        public Int64 ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Profesion { get; set; }

        public Contact_Profile Contact { get; set; }

        public Experience Experience { get; set; }
	  
    }
}