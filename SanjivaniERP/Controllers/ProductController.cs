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
    public class ProductController : Controller
    {
        ClsProductBALcs objPartnerBAL = new ClsProductBALcs();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Product()
        {
            return View();
        }
        public ActionResult Domain()
        {
            int CatId = 1;
            var d = objPartnerBAL.GetDoaminList(CatId);
            return View(d);
        }
        public ActionResult AddDomain(int ProductId)
        {
            ProductBusinessModal Pd = new ProductBusinessModal();
            Pd.ProductId = ProductId;
           
            return View(Pd);
        }
        public ActionResult _partialAddProduct(string productId)
        {
            //if (productId != "0")
            //{
                var d = objPartnerBAL.GetProductById(Convert.ToInt32(productId));
                return View(d);
           // }
           //else
           // {
               
               // return View();
            //}
                
        }
        public ActionResult SetDomain(ProductBusinessModal Pd, HttpPostedFileBase[] postedFile)
        {
            foreach (HttpPostedFileBase file in postedFile)
            {
                if (file != null)
                {
                    var filename = Path.GetFileName(file.FileName);

                  //  var filename1 = Path.GetFileName(file.FileName);
                    Pd.PropductImage = Convert.ToString(Path.GetFileName(file.FileName));
                    if (filename != null)
                    {
                        var Type = 0;
                        var filePath = Server.MapPath("~/Documents/ProductImage/" + filename);
                        file.SaveAs(filePath);
                        // var UploadDocument = objPartnerBAL.SaveUploadChennelPartnerDoc(filename1, EventsTitleList, Type);
                    }
                }
            }
            var Res = objPartnerBAL.SetDomain(Pd);
            return RedirectToAction("Domain", "Product");
        }
        public ActionResult DeleteProduct(int ProductId)
        {
            bool res = objPartnerBAL.deleteProduct(ProductId);
            return RedirectToAction("Domain", "Product");
        }
    }
}