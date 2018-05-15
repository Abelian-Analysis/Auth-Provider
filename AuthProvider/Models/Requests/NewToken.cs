using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthProvider.Models;

namespace AuthProvider.Models.Requests
{
    public class NewToken
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Service { get; set; }
        public string err { get; set; }
    }
}
