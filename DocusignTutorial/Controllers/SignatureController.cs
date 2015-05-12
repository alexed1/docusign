using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using RestSharp;

namespace DocusignTutorial.Controllers
{
    public class SignatureController : Controller
    {

        string endpoint = "https://demo.docusign.net/restapi/v2/";
        



        // GET: Signature
        public ActionResult Index()
        {
            ShowLoginInfo();
            RequestSignature();

            return View();

        }

        public ActionResult ShowLoginInfo()
        {
            string header_authstring =
               @"{""Username"": ""9b322d6f-e6d0-49b0-b609-5c896318d366"", ""Password"": ""scion12"",""IntegratorKey"": ""DOCU-af51f9bf-1b53-4ca7-b5e2-24adcbb5e6f9""}";

            var client = new RestClient();
            client.BaseUrl = new Uri(endpoint + "login_information");

            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("X-DocuSign-Authentication", header_authstring);

            IRestResponse response = client.Execute(request);

          

            return View(response);
        }

        public ActionResult RequestSignature()
        {
            return View();
        }


    }
}