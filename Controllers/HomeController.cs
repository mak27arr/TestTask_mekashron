using Microsoft.Web.Services3.Messaging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using TestTask.Models;

namespace TestTask.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            var isapi = new isapiSOAP.ICUTechClient();
            isapi.Login(ViewBag, ViewBag, "");
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login ldata)
        {
            var isapi = new isapiSOAP.ICUTechClient();
            string response = isapi.Login(ldata.login, ldata.password, Request.UserHostAddress);
            var json = JObject.Parse(response);
            if (json.ContainsKey("ResultCode"))
            {
                ViewBag.ResultCode = "-1";
                ViewBag.Msg = json["ResultMessage"].ToString();
                return View("Index");
            }
            ViewBag.ResultCode = "1";
            ViewBag.Msg = json;
            return View("Index");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterInfo data)
        {
            var isapi = new isapiSOAP.ICUTechClient();
            ViewBag.Response = isapi.RegisterNewCustomer(data.email, data.password, data.firstName, data.lastName, data.mobile, data.countryID, data.aID, data.signupIP);
            return View();
        }
    }
}