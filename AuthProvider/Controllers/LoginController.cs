using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using AuthProvider.Models;
using AuthProvider.Handlers;

namespace AuthProvider.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login(Models.Requests.NewToken newTokenRequest)
        {
            if(Request.Method == "GET")
            {
                ViewData["service"] = newTokenRequest.Service;
                ViewData["error"] = newTokenRequest.err;
                return View();
            }
            else if(Request.Method == "POST")
            {
                try
                {
                    NewTokenRequestHandler handler = new NewTokenRequestHandler(newTokenRequest);
                    if (handler.VerifyUser())
                    {
                        return Redirect(newTokenRequest.Service + "?jwt=" + HttpUtility.UrlEncode(handler.GenerateJWT()));
                    }
                    else return Redirect("/Login?service=" + newTokenRequest.Service + "&err=LoginFailed");
                }catch(Exception E)
                {
                    Logger.LogError("Got exception while handling new token request: " + E.ToString());
                    return StatusCode(500);
                }
                
            }
            else
            {
                return StatusCode(422);
            }
        }


    }
}