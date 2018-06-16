using DevFramework.Core.CrossCuttingConcerns.Security.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevFramework.NorthWind.MVCWebUI.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public string Login()
        {
            AuthenticationHelper.CreateAuthCookie(
                new Guid(), 
                "UlmoBlack", 
                "ulmoblack@gmail.com", 
                DateTime.Now.AddDays(15), 
                new[] { "Student" }, 
                false, 
                "Atakan", 
                "Albayrak");

            return "User is authenticated!";
        }
    }
}