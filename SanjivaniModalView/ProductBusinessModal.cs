using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SanjivaniModalView
{
    public class ProductBusinessModal
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductCatId { get; set; }
        public string DomainERPCode { get; set; }
        public string ProductCode { get; set; }
        public string DomainProviderCode { get; set; }
        public string SACCode { get; set; }
        public string RegistrartionPrice { get; set; }
        public string RenewalPrice { get; set; }
        public string TransferPrice { get; set; }
        public string DomainregistrationPrice { get; set; }
        public string PropductImage { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
    }
}
