using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DocusignTutorial.Services;

namespace DocusignTutorial.Controllers
{
    public class EnvelopeController : Controller
    {
        public string username;
        public string password;
        public string integratorKey;
        public string endpoint;
        public string BaseUrl;

        public EnvelopeController()
        {
             var appSettings = ConfigurationManager.AppSettings;
             username = appSettings["username"] ?? "Not Found"; 			// your account email
             password = appSettings["password"] ?? "Not Found"; 			// your account password
             integratorKey = appSettings["IntegratorKey"] ?? "Not Found";	// your account Integrator Key (found on Preferences -> API page)
             BaseUrl = appSettings["BaseUrl"] ?? "Not Found";
        }

        // GET: Envelope
        public ActionResult Index()
        {
            var url = BaseUrl + "envelopes/";
            var response = API.get(url, username, password, integratorKey);
            return View(response);
        }



        public ActionResult GetById(int id)
        {
            //============================================================================
            //  STEP 2 - Get Envelope Information
            //============================================================================

            // append "/envelopes/{envelopeId}/recipientId" to baseURL and use as endpoint for Get Recipient Status api call
            var url = endpoint + "/envelopes/" + id + "/recipients";

            // set request url, method, and headers
            var request = API.initializeRequest(url, "GET", null, username, password, integratorKey);

            // read the http response
            var response = API.getResponseBody(request);

            //--- display results
            Debug.Print("\nAPI Call Result: \n\n" + API.prettyPrintXml(response));

            return View(response);
        }
    }
}