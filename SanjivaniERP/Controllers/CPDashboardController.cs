using SanjivaniBusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SanjivaniERP.Controllers
{
    public class CPDashboardController : Controller
    {
        ClsCCPDashboard objCPDash = new ClsCCPDashboard();
        // GET: CPDashboard
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Dashboard()
        {
            string CPCustId = "";
            var CPDashCount = objCPDash.getCpDashCount(CPCustId);
            ViewBag.CPCount = CPDashCount;
            return View();
        }

        public ActionResult CPCustomer(string CustID)
        {
            string CPCustId = "";
            var CPCustomerList = objCPDash.GetCPCustomerList(CPCustId);
           
            return View();
        }
    }
}