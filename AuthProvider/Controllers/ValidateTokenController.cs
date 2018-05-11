using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AuthProvider.Controllers
{
    [Route("[controller]")]
    public class ValidateTokenController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}