using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthProvider.Models;

namespace AuthProvider.Requests
{
    public class NewTokenRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
