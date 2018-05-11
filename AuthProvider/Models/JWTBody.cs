using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthProvider.Models
{
    public class JWTBody
    {
        public string Username;
        public string Group;
        public DateTime Iat;
    }
}
