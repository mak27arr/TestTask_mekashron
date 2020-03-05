using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestTask.Models
{
    public class RegisterInfo
    {
        public string email { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string mobile { get; set; }
        public int countryID { get; set; }
        public int aID { get; set; }
        public string signupIP { get; set; }

    }
}