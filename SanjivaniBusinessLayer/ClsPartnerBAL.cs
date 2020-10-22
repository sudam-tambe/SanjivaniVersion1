using SanjivaniDataLinkLayer;
using SanjivaniModalView;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Web;
using System.Data;

namespace SanjivaniBusinessLayer
{
    public class ClsPartnerBAL
    {
        InfPartner objInfPub = new SanjivaniDataLinkLayer.ImpPartner();

        public int SaveChennelPartnerDetails(ChennelpartnerModel model, HttpPostedFileBase[] postedFile)
        {
            return objInfPub.SaveChennelPartnerDetails(model, postedFile);
        }
        public int SaveCPCRegisterDetails(CPCchannelPartnerModel model, HttpPostedFileBase[] postedFile)
        {
            return objInfPub.SaveCPCDetails(model, postedFile);
        }

        public int SaveDirectorBusinessDetails(DirectorBusinessModel model, HttpPostedFileBase[] postedFile)
        {
            return objInfPub.SaveDirectorBusinessDetails(model, postedFile);
        }

        public List<TypeOfHosting> GetTypeofHosting()
        {
            return objInfPub.getTypeofHosting();
        }

        public List<HostingPlatF>GetHostingPlatform()
        {
            return objInfPub.getHostingPlatform();
        }

        public int UpdateCPCRegisterDetails(CPCchannelPartnerModel model, HttpPostedFileBase[] postedFile)
        {
            return objInfPub.UpdateCPCRegisterDetails(model, postedFile);
        }
        public int UpdateDirectorBusinessRegister(DirectorBusinessModel model, HttpPostedFileBase[] postedFile)
        {
            return objInfPub.UpdateDirectorBusinessRegister(model, postedFile);
        }

        public bool SetCPBusinessDtl(BusinessDetails bD)
        {
            return objInfPub.setCPBusinessDtl(bD);
        }

        public List<PaymentType> GetPaymentmode()
        {
            return objInfPub.getPaymentmode();
        }

        public List<Bank> GetBank()
        {
            return objInfPub.getBank();
        }

        public List<Account> GetAccountType()
        {
            return objInfPub.getAccountType();
        }
        public List<BankName> GetBankName()
        {
            return objInfPub.GetBankName();
        }

        

        public List<State> GetBindState()
        {
            return objInfPub.GetBindState();
        }
        public List<CPCategory> GetBindCPCategory()
        {
            return objInfPub.GetBindCPCategory();
        }

        public bool setCPBankDtl(BankDetails bd)
        {
            return objInfPub.SetCPBankDtl(bd);
        }
        public bool setCPCBankDtl(BankDetails bd)
        {
            return objInfPub.SetCPCBankDtl(bd);
        }
        public bool setDirectorBankDtl(BankDetails bd)
        {
            return objInfPub.SetDirectorBankDtl(bd);
        }
        

        public List<CPCchannelPartnerModel> GetBindCPCustomer()
        {
            return objInfPub.GetBindCPCustomer();
        }

        public List<CompanyType> BindCompanyType()
        {
            return objInfPub.GetBindCompanyType();
        }


        public List<ChennelpartnerModel> GetChennelPartnerList()
        {
            return objInfPub.GetChennelPartnerList();
        }
        public List<CPCchannelPartnerModel> GetCPCChannelPartnerList()
        {
            return objInfPub.GetCPCChannelPartnerList();
        }

        public int SaveUploadChennelPartnerDoc(string filename1, int CustID, int type)
        {
            return objInfPub.SaveUploadChennelPartnerDocument(filename1, CustID, type);
        }
        public int SaveUploadCPCDoc(string filename1, int CustID, int type)
        {
            return objInfPub.SaveUploadCPCDocument(filename1, CustID, type);
        }
        public int SaveUploadDirectorDoc(string filename1, int CustID, int type)
        {
            return objInfPub.SaveUploadDirectorDoc(filename1, CustID, type);
        }
        

        public CPCchannelPartnerModel GetCPCChannelEdit(string custId)
        {
            return objInfPub.GetCPCChannelList(custId);
        }
        public DirectorBusinessModel GetDirectorChannelEdit(string custId)
        {
            return objInfPub.GetDirectorChannelEdit(custId);
        }
        

        public List<DirectorBusinessModel> GetDirectorBusinessOwnerList()
        {
            return objInfPub.GetDirectorBusinessOwnerList();
        }
        public bool RejectChannalPartner(int CustId)
        {
            return objInfPub.rejectChannalPartner(CustId);
        }
        public DataTable GetLoginDetail(string id)
        {
            return objInfPub.getLoginDetail(id);
        }
        public DataSet GetFolder()
        {
            return objInfPub.getFolder();
        }

        public List<UserIntraction> GetUserIntraction(int custId)
        {
            return objInfPub.getUserIntraction(custId);
        }
        
        public bool setUserIntarction(UserIntraction usD)
        { 
            return objInfPub.SetUserIntarction(usD);

        }
        public ChennelpartnerModel GetChannalPartnerDtl(int custId)
        {
            return objInfPub.getChannalPartnerDtl(custId);
        }

        public DirectorBusinessModel GetDirectorBusinessOwners(string custId)
    {
        return objInfPub.GetDirectorBusinessOwners(custId);

    }

        public int _partialCPSave(ChennelpartnerModel model)
        {
            return objInfPub._PartialCPSave(model);
        }

        public int _partialCPCSave(CPCchannelPartnerModel model)
        {
            return objInfPub._SaveCPCPartialView(model);
        }
		
        public DataTable CheckUserIdExists(string userId)
        {
            return objInfPub.checkUserIdExists(userId);
        }

        public DataTable CheckEmailExists(string email)
        {
            return objInfPub.checkEmailExists(email);
        }

        public ChennelpartnerModel GetCPForEdit(int Custid)
        {
            return objInfPub.getCPForEdit(Custid);
        }

        public BusinessDetails _partialGetCPBusinessDtl(string custId)
        {
            return objInfPub._partialgetCPBusinessDtl(custId);
        }

        public CountryState GetCountryStateForCPPersonal(int CustId)
        {
            return objInfPub.getCountryStateForCPPersonal(CustId);
        }

        public BankDetails _partialGetCPBankDtl(string custId)
        {
            return objInfPub._partialgetCPBankDtl(custId);
        }

        public bool DeleteCP(int custId)
        {
            return objInfPub.deleteCp(custId);
        }
        public bool GetDeleteUserIntraction(int IntractionId)
        {
            return objInfPub.DeleteUserIntraction(IntractionId);
        }

        public List<Documents1> getCpDocument(int custId)
        {
            return objInfPub.GetCPDocument(custId);
        }

        public bool ApproveCP(int CustId)
        {
            return objInfPub.approveCP(CustId);
        }
        public List<Documents1> getDirectorDocument(int custId)
        {
            return objInfPub.getDirectorDocument(custId);
        }

        

        //public int UpdateDirectorBusinessRegister(DirectorBusinessModel model, HttpPostedFileBase[] postedFile)
        //     {
        //         return objInfPub.UpdateDirectorBusinessRegister(model, postedFile);
        //     }
        //public int SaveUploadDirectorDoc(string filename1, int CustID, int type)
        //     {
        //         return objInfPub.SaveUploadDirectorDoc(filename1, CustID, type);
        //     }
        //public DirectorBusinessModel GetDirectorChannelEdit(int custId)
        //     {
        //         return objInfPub.GetDirectorChannelEdit(custId);
        //     }


    }
}
