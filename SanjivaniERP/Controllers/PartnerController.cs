using Microsoft.AspNet.Identity;
using SanjivaniBusinessLayer;
using SanjivaniERP.Models;
using SanjivaniModalView;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.Owin;
using System.Net;
using System.Data;
using Hangfire;
using System.Net.Mime;

namespace SanjivaniERP.Controllers
{
    public class PartnerController : Controller
    {
        public ApplicationSignInManager _signInManager;
        public ApplicationUserManager _userManager;
        ClsPartnerBAL objPartnerBAL = new ClsPartnerBAL();
        // GET: Partner
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult _partialSetEditCPBusinessDetail(BusinessDetails BD)
        {
            BD.TypeofHosting = Convert.ToString(BD.TypeofHosting1);
            BD.HostingPlatform = Convert.ToString(BD.HostingPlatform1);
            BD.CustId = Convert.ToString(Session["CustId"]);
            Session["Domain"] = BD.CurrentDomainProvide;
            bool res = objPartnerBAL.SetCPBusinessDtl(BD);
            //if (res)
            //{
            //    //int Res = Mb.UpdateMemPassword(UserId, Mp.Password);
            //    return Json(new { success = true, responseText = "The attached file is not supported." }, JsonRequestBehavior.AllowGet);
            //}
            //else
            //{
            //    return Json(new { Success = false, Messege = "Please Enter Valid Old Password", Status = 400 });
            //}
            //Session["Tab"] = "2";
            return RedirectToAction("Chennelpartner", "Partner");
            //return View();
        }
        public ActionResult _partialSetEditBankDeatil(BankDetails bd)
        {
            bd.BankName = Convert.ToString(bd.BankName1);
            bd.CustId = Convert.ToString(Session["CustId"]);
            bool res = objPartnerBAL.setCPBankDtl(bd);

            Session["Tab"] = "3";
            return RedirectToAction("Chennelpartner", "Partner");
        }
        public ActionResult Chennelpartner(string CustId)
        {
            if (CustId != null)
                Session["CustId"] = CustId;
            else
                CustId = Convert.ToString(Session["CustId"]);
            ChennelpartnerModel dc = new ChennelpartnerModel();


            ViewBag.StateList = new SelectList(objPartnerBAL.GetBindState(), "StateId", "StateName");
            ViewBag.BindCPCategory = new SelectList(objPartnerBAL.GetBindCPCategory(), "CategoryId", "CategoryName");
            ViewBag.BindCompanyType = new SelectList(objPartnerBAL.BindCompanyType(), "Compid", "CompanyName");
            if (CustId != null)
            {
                dc.CustId = CustId;
                return View(dc);
            }
            return View();
        }
        public bool DirectoryExists(string directory)
        {
            bool directoryExists;

            var request = (FtpWebRequest)WebRequest.Create(directory);
            request.Method = WebRequestMethods.Ftp.ListDirectory;
            request.Credentials = new NetworkCredential("pioneers", "d@8Pg~4Ea0Dv$9C");

            try
            {
                using (request.GetResponse())
                {
                    directoryExists = true;
                }
            }
            catch (WebException)
            {
                directoryExists = false;
            }

            return directoryExists;
        }
        public static bool CheckFileExistOnFTP(string ServerUri, string FTPUserName, string FTPPassword)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ServerUri);
            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            request.Credentials = new NetworkCredential(FTPUserName, FTPPassword);
            //request.Method = WebRequestMethods.Ftp.GetFileSize;
            // request.Method = WebRequestMethods.Ftp.GetDateTimestamp;

            try
            {
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                return true;
            }
            catch (WebException ex)
            {
                FtpWebResponse response = (FtpWebResponse)ex.Response;
                if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                {
                    return false;
                }
            }
            return true;
        }
        public ActionResult ChannaPartnerList()
        {
            DataSet ds = new DataSet();
            //string SourceDomain = "ftp://pioneers@103.235.106.17/shop.pioneersoft.co.in";
            //string DestinationDomain = "ftp://pioneers@103.235.106.17/";
            //NetworkCredential credentials = new NetworkCredential("pioneers", "d@8Pg~4Ea0Dv$9C");
            //ds = objPartnerBAL.GetFolder();
            ////ds.Tables[0].Rows.Clear();
            ////ds.Tables[1].Rows.Clear();

            //string directoryUrl = DestinationDomain + "shop.pioneersoft.co.in";

            //if (!DirectoryExists(directoryUrl))
            //{
            //    try
            //    {
            //        //Console.WriteLine($"Creating {name}");
            //        FtpWebRequest requestDir = (FtpWebRequest)WebRequest.Create(directoryUrl);
            //        requestDir.Method = WebRequestMethods.Ftp.MakeDirectory;
            //        requestDir.Credentials = credentials;
            //        requestDir.GetResponse().Close();
            //    }
            //    catch (WebException ex)
            //    {
            //        FtpWebResponse response = (FtpWebResponse)ex.Response;
            //        if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
            //        {
            //            // probably exists already
            //        }
            //        else
            //        {
            //            RedirectToAction("ChannaPartnerList", "Partner");
            //        }
            //    }


            //}
            //var cssFiles = Directory.GetFiles(Server.MapPath("~/Views")
            //                             );
            var ChennelPartnerList = objPartnerBAL.GetChennelPartnerList();
            ViewBag.ChennelPartnerList = ChennelPartnerList;
            //UpLoadStoreFront();
            // BackgroundJob.Enqueue(() => UpLoadStoreFront());
            return View();

        }
        public ActionResult ViewCP(int CustId)
        {
            return View();
        }
        public ActionResult UpL()
        {
            if (Session["Dothis"].ToString() == "1")
            {
                string Domaim = Session["Domain"].ToString();
                BackgroundJob.Enqueue(() => UpLoadStoreFront(Domaim));
                //  UpLoadStoreFront(Domaim);

            }
            //Session["Completemsg"] = "Yes";
            Session["Dothis"] = "0";
            return RedirectToAction("ChannaPartnerList", "Partner");
        }
        public void UpLoadStoreFront(string Domaim)
        {
            //RedirectToAction("NewCP", "Partner");

            DataSet ds = new DataSet();
            string SourceDomain = "ftp://pioneers@103.235.106.17/shop.pioneersoft.co.in";
            string DestinationDomain = "ftp://pioneers@103.235.106.17/" + Domaim;
            NetworkCredential credentials = new NetworkCredential("pioneers", "d@8Pg~4Ea0Dv$9C");
            ds = objPartnerBAL.GetFolder();
            //ds.Tables[0].Rows.Clear();
            //ds.Tables[1].Rows.Clear();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                string directoryUrl = DestinationDomain + dr["Folder"].ToString();

                if (!DirectoryExists(directoryUrl))
                {
                    try
                    {
                        //Console.WriteLine($"Creating {name}");
                        FtpWebRequest requestDir = (FtpWebRequest)WebRequest.Create(directoryUrl);
                        requestDir.Method = WebRequestMethods.Ftp.MakeDirectory;
                        requestDir.Credentials = credentials;
                        requestDir.GetResponse().Close();
                    }
                    catch (WebException ex)
                    {
                        FtpWebResponse response = (FtpWebResponse)ex.Response;
                        if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                        {
                            // probably exists already
                        }
                        else
                        {
                            RedirectToAction("ChannaPartnerList", "Partner");
                        }
                    }

                }
            }
            foreach (DataRow dr in ds.Tables[1].Rows)
            {
                try
                {
                    //NetworkCredential credentials = new NetworkCredential("pioneers", "d@8Pg~4Ea0Dv$9C");
                    //var cssFiles = Directory.GetFiles(Server.MapPath("~/Views"));
                    var cssFiles = Directory.GetFiles(System.Web.Hosting.HostingEnvironment.MapPath(dr["FileName"].ToString().Trim()));
                    foreach (string file in cssFiles)
                    {
                        using (WebClient client = new WebClient())
                        {
                            string url = "ftp://pioneers@103.235.106.17/" + Domaim + dr["DestinationFile"].ToString().Trim() + "/";
                            if (!CheckFileExistOnFTP(url + Path.GetFileName(file), "pioneers", "d@8Pg~4Ea0Dv$9C"))
                            {
                                client.Credentials = credentials;
                                client.UploadFile(url + Path.GetFileName(file), file);

                            }
                            //Console.WriteLine($"Uploading {file}");

                        }
                    }
                    Session["Completemsg"] = "Yes";
                    Session["Dothis"] = "0";
                }
                catch (Exception)
                {

                    RedirectToAction("ChannaPartnerList", "Partner");
                }

            }

        }
        public ActionResult EditChannalPartner(string CustId)
        {
            Session["CustId"] = CustId;
            ViewBag.PaymentMode = new SelectList(objPartnerBAL.GetPaymentmode(), "PaymentModeId", "PaymentMode");
            ViewBag.Accountype = new SelectList(objPartnerBAL.GetAccountType(), "AccountTypeId", "AccountType");
            ViewBag.StateList = new SelectList(objPartnerBAL.GetBindState(), "StateId", "StateName");
            ViewBag.BindCPCategory = new SelectList(objPartnerBAL.GetBindCPCategory(), "CategoryId", "CategoryName");
            ViewBag.BindCompanyType = new SelectList(objPartnerBAL.BindCompanyType(), "Compid", "CompanyName");
            ChennelpartnerModel Cm = objPartnerBAL.GetChannalPartnerDtl(Convert.ToInt32(CustId));
            return View(Cm);
        }
        public ActionResult NewCP()
        {
            ViewBag.PaymentMode = new SelectList(objPartnerBAL.GetPaymentmode(), "PaymentModeId", "PaymentMode");
            ViewBag.Accountype = new SelectList(objPartnerBAL.GetAccountType(), "AccountTypeId", "AccountType");
            ViewBag.StateList = new SelectList(objPartnerBAL.GetBindState(), "StateId", "StateName");
            ViewBag.BindCPCategory = new SelectList(objPartnerBAL.GetBindCPCategory(), "CategoryId", "CategoryName");
            ViewBag.BindCompanyType = new SelectList(objPartnerBAL.BindCompanyType(), "Compid", "CompanyName");
            return View();
        }
        [HttpPost]
        public ActionResult SaveChennelPartnerDetails1(FormCollection fc, ChennelpartnerModel model, HttpPostedFileBase[] postedFile)
        {
            //if (ModelState.IsValid)
            //{
            //    var user = new ApplicationUser { UserName = model.UserName, Email = model.EmailID };
            //    var result =  UserManager.CreateAsync(user, model.pwd);

            //}

            ///If we got this far, something failed, redisplay form
            //return View(model);
            if (ModelState.IsValid)
            {
                var EventsTitleList = objPartnerBAL.SaveChennelPartnerDetails(model, postedFile);
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
                                var filePath = Server.MapPath("~/Documents/Logo/" + filename1);
                                file.SaveAs(filePath);
                                var UploadDocument = objPartnerBAL.SaveUploadChennelPartnerDoc(filename1, EventsTitleList, Type);
                            }
                        }
                        else if (k == 1)
                        {
                            var Type = 1;
                            var filePath = Server.MapPath("~/Documents/Pan/" + filename);
                            file.SaveAs(filePath);
                            var UploadDocument = objPartnerBAL.SaveUploadChennelPartnerDoc(filename, EventsTitleList, Type);
                        }
                        else if (k == 2)
                        {
                            var Type = 2;
                            var path = Path.Combine(Server.MapPath("~/Documents/RegDocument/"), filename);
                            file.SaveAs(path);
                            var UploadDocument = objPartnerBAL.SaveUploadChennelPartnerDoc(filename, EventsTitleList, Type);
                        }
                        else if (k == 3)
                        {
                            var Type = 3;
                            var path = Path.Combine(Server.MapPath("~/Documents/ProfilePhoto/"), filename);
                            file.SaveAs(path);
                            var UploadDocument = objPartnerBAL.SaveUploadChennelPartnerDoc(filename, EventsTitleList, Type);
                        }
                        else if (k == 4)
                        {
                            var Type = 4;
                            var path = Path.Combine(Server.MapPath("~/Documents/OwnerSignature/"), filename);
                            file.SaveAs(path);
                            var UploadDocument = objPartnerBAL.SaveUploadChennelPartnerDoc(filename, EventsTitleList, Type);
                        }
                        k++;
                    }
                }
                var ChennelPartnerList = objPartnerBAL.GetChennelPartnerList();
                ViewBag.ChennelPartnerList = ChennelPartnerList;
            }

            string url = "http://bds.pioneersoft.co.in";
            return Redirect("http://bds.pioneersoft.co.in");
        }
        [HttpPost]
        public ActionResult SaveChennelPartnerDetails(FormCollection fc, ChennelpartnerModel model, HttpPostedFileBase[] postedFile)
        {
            if (ModelState.IsValid)
            {
                var EventsTitleList = objPartnerBAL.SaveChennelPartnerDetails(model, postedFile);
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
                                var filePath = Server.MapPath("~/Documents/Logo/" + filename1);
                                file.SaveAs(filePath);
                                var UploadDocument = objPartnerBAL.SaveUploadChennelPartnerDoc(filename1, EventsTitleList, Type);
                            }
                        }
                        else if (k == 1)
                        {
                            var Type = 1;
                            var filePath = Path.Combine(Server.MapPath("~/Documents/Pan/"), filename);
                            file.SaveAs(filePath);
                            var UploadDocument = objPartnerBAL.SaveUploadChennelPartnerDoc(filename, EventsTitleList, Type);
                        }
                        else if (k == 2)
                        {
                            var Type = 2;
                            var path = Path.Combine(Server.MapPath("~/Documents/RegDocument"), filename);
                            file.SaveAs(path);
                            var UploadDocument = objPartnerBAL.SaveUploadChennelPartnerDoc(filename, EventsTitleList, Type);
                        }
                        else if (k == 3)
                        {
                            var Type = 3;
                            var path = Path.Combine(Server.MapPath("~/Documents/ProfilePhoto"), filename);
                            file.SaveAs(path);
                            var UploadDocument = objPartnerBAL.SaveUploadChennelPartnerDoc(filename, EventsTitleList, Type);
                        }
                        else if (k == 4)
                        {
                            var Type = 4;
                            var path = Path.Combine(Server.MapPath("~/Documents/OwnerSignature"), filename);
                            file.SaveAs(path);
                            var UploadDocument = objPartnerBAL.SaveUploadChennelPartnerDoc(filename, EventsTitleList, Type);
                        }
                        k++;
                    }
                }
                var ChennelPartnerList = objPartnerBAL.GetChennelPartnerList();
                ViewBag.ChennelPartnerList = ChennelPartnerList;
            }


            return View();
        }

        public ActionResult RejectCP()
        {
            bool res = objPartnerBAL.RejectChannalPartner(Convert.ToInt32(Session["CustId"]));
            return RedirectToAction("ChannaPartnerList", "Partner");
        }
        public ActionResult UserIntraction(string CustId)
        {
            UserIntraction cd = new UserIntraction();
            cd.CustID = Convert.ToInt32(CustId);
            //if (IntractionId != "")
            //    cd = objPartnerBAL.GetDeleteUserIntraction(Convert.ToInt32(IntractionId));
            return View();
        }
        [HttpGet]
        public JsonResult DeleteUserIntraction(string IntractionId)
        {
            var CustId = Convert.ToString(Session["CustId"]);
            bool res = objPartnerBAL.GetDeleteUserIntraction(Convert.ToInt32(IntractionId));
            if (res)
            {
                return Json(new { Status = 200 }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { Status = 400 }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult _PartialUserIntarction(string CustId)
        {
            Session["Msg"] = "";
            if (CustId != "")
                ViewBag.UserIntract = objPartnerBAL.GetUserIntraction(Convert.ToInt32(CustId));
            return View();
        }

        public ActionResult EditUserIntraction(string CustId)
        {

            return View();
        }

        public ActionResult SetUserIntraction(UserIntraction UsD)
        {
            UsD.CustID = Convert.ToInt32(Session["CustId"]);
            bool res = objPartnerBAL.setUserIntarction(UsD);
            if (res)
            {
                //int Res = Mb.UpdateMemPassword(UserId, Mp.Password);
                return Json(new { success = false, responseText = "The attached file is not supported." }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { Success = false, Messege = "Please Enter Valid Old Password", Status = 400 });
            }

        }
        public ActionResult _PartialCPPerstionalDtl(string CustId)
        {
            Session["Msg"] = "";
            ViewBag.StateList = new SelectList(objPartnerBAL.GetBindState(), "StateId", "StateName");
            ViewBag.BindCPCategory = new SelectList(objPartnerBAL.GetBindCPCategory(), "CategoryId", "CategoryName");
            if (CustId != "")
            {
                var d = objPartnerBAL.GetCPForEdit(Convert.ToInt32(CustId));
                return View(d);
            }
            return View();
        }

        public ActionResult _PartialCPBusinessDtl(string CustId)
        {
            Session["Msg"] = "";
            ViewBag.TypeOfHosting = new SelectList(objPartnerBAL.GetTypeofHosting(), "TypeHostingId", "TypeofHosting");
            ViewBag.HostingPlatForm = new SelectList(objPartnerBAL.GetHostingPlatform(), "HostingPlatformId", "HostingPlatForm");
            ViewBag.StateList = new SelectList(objPartnerBAL.GetBindState(), "StateId", "StateName");
            ViewBag.BindCompanyType = new SelectList(objPartnerBAL.BindCompanyType(), "Compid", "CompanyName");
            if (CustId != "")
            {
                var d = objPartnerBAL._partialGetCPBusinessDtl(CustId);
                Session["Domain"] = d.CurrentDomainProvide;
                return View(d);
            }
            else
                return View();
        }
        public JsonResult getuserdat(string CustId)
        {
            Session["Msg"] = "";
            Session["Tab"] = "";
            var list = objPartnerBAL.GetCountryStateForCPPersonal(Convert.ToInt32(CustId));
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult _PartialgetCPBankDtl(string CustId)
        {
            Session["Msg"] = "";
            ViewBag.bank = new SelectList(objPartnerBAL.GetBank(), "BankId", "BankName");
            ViewBag.PaymentMode = new SelectList(objPartnerBAL.GetPaymentmode(), "PaymentModeId", "PaymentMode");
            ViewBag.Accountype = new SelectList(objPartnerBAL.GetAccountType(), "AccountTypeId", "AccountType");
            if (CustId != "")
            {
                var d = objPartnerBAL._partialGetCPBankDtl(CustId);
                return View(d);
            }
            else
                return View();
        }
        public ActionResult DeleteCp()
        {
            bool res = objPartnerBAL.DeleteCP(Convert.ToInt32(Session["CustId"]));
            return RedirectToAction("ChannaPartnerList", "Partner");
        }
        public ActionResult _partialCPDocument(string CustId)
        {
            return View();
        }
        public ActionResult _PartialgetCPDocument()
        {
            int CustId = Convert.ToInt32(Session["CustId"]);
            var d = objPartnerBAL.getCpDocument(CustId);
            return View(d);
        }
        public ActionResult ApproveCp()
        {
            Session["Completemsg"] = "No";
            Session["Dothis"] = "1";
            bool res = objPartnerBAL.ApproveCP(Convert.ToInt32(Session["CustId"]));
            // Session["Domain"] = model.ObjBusinessDetails.CurrentDomainProvide;
            return RedirectToAction("UpL", "Partner");
        }

        public ActionResult _SetCPDocument(HttpPostedFileBase[] postedFile)
        {
            Session["Tab"] = "4";
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
                    else if (k == 1)
                    {
                        var Type = 1;
                        var filePath = Path.Combine(Server.MapPath("~/Documents/Pan/"), filename);
                        file.SaveAs(filePath);
                        var UploadDocument = objPartnerBAL.SaveUploadChennelPartnerDoc(filename, EventsTitleList, Type);
                    }
                    else if (k == 2)
                    {
                        var Type = 2;
                        var path = Path.Combine(Server.MapPath("~/Documents/RegDocument/"), filename);
                        file.SaveAs(path);
                        var UploadDocument = objPartnerBAL.SaveUploadChennelPartnerDoc(filename, EventsTitleList, Type);
                    }
                    else if (k == 3)
                    {
                        var Type = 3;
                        var path = Path.Combine(Server.MapPath("~/Documents/ProfilePhoto/"), filename);
                        file.SaveAs(path);
                        var UploadDocument = objPartnerBAL.SaveUploadChennelPartnerDoc(filename, EventsTitleList, Type);
                    }
                    else if (k == 4)
                    {
                        var Type = 4;
                        var path = Path.Combine(Server.MapPath("~/Documents/OwnerSignature/"), filename);
                        file.SaveAs(path);
                        var UploadDocument = objPartnerBAL.SaveUploadChennelPartnerDoc(filename, EventsTitleList, Type);
                    }
                    k++;
                }
            }
            return RedirectToAction("Chennelpartner", "Partner");
        }
    }
}