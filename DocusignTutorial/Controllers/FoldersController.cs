using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DocusignTutorial.Services;

namespace DocusignTutorial.Controllers
{

    public class FoldersController : Controller
    {
        public string username;
        public string password;
        public string integratorKey;
        public string endpoint;
        public string BaseUrl;

        public FoldersController()
        {
            var appSettings = ConfigurationManager.AppSettings;
            username = appSettings["username"] ?? "Not Found"; 			// your account email
            password = appSettings["password"] ?? "Not Found"; 			// your account password
            integratorKey = appSettings["IntegratorKey"] ?? "Not Found";	// your account Integrator Key (found on Preferences -> API page)
            BaseUrl = appSettings["BaseUrl"] ?? "Not Found";

        }
        // GET: Folder
        public ActionResult Index()
        {
            var url = BaseUrl + "/folders/";
            var response = API.get(url, username, password, integratorKey);

            return View(response);
        }
    }
}