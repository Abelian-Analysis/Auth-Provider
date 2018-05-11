using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthProvider.Models
{
    public class JWTHeader
    {
        public string Alg = "RS256";
        public string Typ = "JWT";
    }
}
