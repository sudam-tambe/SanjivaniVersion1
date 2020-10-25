using SanjivaniBusinessLayer;
using SanjivaniModalView;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SanjivaniERP.Controllers
{
    public class CPDashboardController : Controller
    {
        ClsPartnerBAL objPartnerBAL = new ClsPartnerBAL();
        ClsCCPDashboard objCPDash = new ClsCCPDashboard();
        // GET: CPDashboard
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Dashboard()
        {
            int CPCustId = 2022; /*Convert.ToInt32(Session["UserId"]);*/
            var CPDashCount = objCPDash.getCpDashCount(CPCustId);
            ViewBag.CPCount = CPDashCount;
            return View();
        }
        public ActionResult CPCustomerList()
        {
            int CPCustId = 2022; /*Convert.ToInt32(Session["UserId"]);*/
            var CPCustomerList = objCPDash.GetCPCustomerList(CPCustId);
            ViewBag.CPCustDashBoardList = CPCustomerList;
            return View();
        }
        public ActionResult CPCustomerDashAddNew(string CustId)
        {
             if (CustId==null)
                Session["CustId"] = CustId;
            else
                CustId = Convert.ToString(Session["CustId"]);
            ChennelpartnerModel dc = new ChennelpartnerModel();

            ViewBag.StateList = new SelectList(objPartnerBAL.GetBindState(), "StateId", "StateName");
            ViewBag.BindCPCategory = new SelectList(objPartnerBAL.GetBindCPCategory(), "CategoryId", "CategoryName");
            //ViewBag.BindCompanyType = new SelectList(objPartnerBAL.BindCompanyType(), "Compid", "CompanyName");
            if (!string.IsNullOrWhiteSpace(CustId))
            {
                dc.CustId = CustId.ToString();
                return View(dc);
            }
            return View();
        }
        public ActionResult _PartialCPPerstionalDtl(string CustId)
        {
          
            if (!string.IsNullOrWhiteSpace(CustId))

                Session["CustId"] = CustId;
            else
                CustId = Convert.ToString(Session["CustId"]);
            ViewBag.StateList = new SelectList(objPartnerBAL.GetBindState(), "StateId", "StateName");
            ViewBag.BindCPCategory = new SelectList(objPartnerBAL.GetBindCPCategory(), "CategoryId", "CategoryName");
            if (!string.IsNullOrWhiteSpace(CustId))
            {
                var d = objCPDash.GetCPForEdit(Convert.ToInt32(CustId));
                return View(d);
            }
            return View();
        }
        //public ActionResult _partialSetPersonalDeatil(ChennelpartnerModel model)
        //{
        //    //bd.BankName = Convert.ToString(bd.BankName1);
        //    model.CustId = model.CustId;
        //    model.ParentId = Convert.ToString(Session["UserId"]);
        //    bool res = objCPDash.SetPersonalDeatil(model);
        //    // bool res = objPartnerBAL.setCPBankDtl(bd);
        //    Session["Tab"] = "1";
        //    return RedirectToAction("CPCustomerDashAddNew", "CPDashboard",new { custid=model.CustId});
        //}
        public ActionResult _PartialCPDashBankDtl()
        {
            ViewBag.bank = new SelectList(objPartnerBAL.GetBank(), "BankId", "BankName");
            ViewBag.PaymentMode = new SelectList(objPartnerBAL.GetPaymentmode(), "PaymentModeId", "PaymentMode");
            ViewBag.Accountype = new SelectList(objPartnerBAL.GetAccountType(), "AccountTypeId", "AccountType");
            return View();
        }
        public ActionResult _PartialCPDashDocument()
        {
            return View();
        }
        public ActionResult _SetCPDashDocument(HttpPostedFileBase[] postedFile)
        {
            Session["Tab"] = "3";
            int EventsTitleList = Convert.ToInt32(Session["CustId"]);
            var k = 0;
            foreach (HttpPostedFileBase file in postedFile)
            {
                if (file != null)
                {
                    var filename = Path.GetFileName(file.FileName);
                    if (k == 0)
                    {
                        var filename1 = Path.GetFileName(file.FileName);
                        if (filename1 != null)
                        {
                            var Type = 0;
                            //  var filePath = Server.MapPath("~/Documents/Logo/" + filename1);
                            // file.SaveAs(filePath);
                            var fileName = Path.GetFileName(file.FileName);
                            var path = Path.Combine(Server.MapPath("~/Documents/Logo/"), fileName);
                            file.SaveAs(path);
                            var UploadDocument = objPartnerBAL.SaveUploadChennelPartnerDoc(filename1, EventsTitleList, Type);
                        }
                    }
                    k++;
                }
            }
            return RedirectToAction("CPCustomerDashAddNew", "CPDashboard",new {custid= EventsTitleList });
        }

        public ActionResult _PartialgetCPDocument()
        {
            int CustId = Convert.ToInt32(Session["CustId"]);
            var d = objPartnerBAL.getCpDocument(CustId);
            return View(d);
        }
        public ActionResult _PartialgetProductList()
        {
            int ProductId = 1002;
            var d = objCPDash.getCpProdcutList(ProductId);
            return View(d);
        }

    }
}