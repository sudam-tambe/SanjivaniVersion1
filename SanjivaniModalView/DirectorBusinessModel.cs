using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SanjivaniModalView
{
   public class DirectorBusinessModel
    {
        public string CustId { get; set; }
        public string RegiDate { get; set; }
        [Required(ErrorMessage = "Please enter User name.")]
        //public string OwnerID { get; set; }
        public string UserId { get; set; }
        public string pwd { get; set; }
        [Required(ErrorMessage = "Please enter Confirm Password.")]
        public string Cpwd { get; set; }
        [Required(ErrorMessage = "Please enter Channel Partner Name")]
        public string OwnerName { get; set; }
        [Required]
        public string mobileNo { get; set; }
        public string AlterMobileNo { get; set; }
        public string EmailID { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string AspUserId { get; set; }
        public string ParentId { get; set; }
        public string CustCategroryId { get; set; }
        public string HolderName { get; set; }
        public int PostedCode { get; set; }
        public string StatusId { get; set; }
        public BankDetails ObjBackDetails { get; set; }
    }
    public class Dashboard
    {
        public string CP { get; set; }
        public string CPC { get; set; }
        public string Director { get; set; }
        public string Customer { get; set; }
        public string Freelancer { get; set; }
        public string Affilate { get; set; }
    }
    public class GHDs
    {
        public string GHDId { get; set; }
        public string GHD { get; set; }
        public string Link { get; set; }
      
    }
    public class OrgChart
    {
        public string Name { get; set; }
        public string ProfilePic { get; set; }
       

    }
    public class VOCust
    {
        public string VocId { get; set; }
        public string Voc { get; set; }

        public string VocDtlId { get; set; }
        public string Ans { get; set; }
    }
    public class GlobalHelpdesk
    {
        public int ImgId { get; set; }

        public int GID { get; set; }
        public string Name { get; set; }
        public HttpPostedFileBase[] files { get; set; }
        public string imagfile { get; set; }
    }
}
