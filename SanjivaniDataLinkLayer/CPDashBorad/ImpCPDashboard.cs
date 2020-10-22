using BandooDataLinkLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SanjivaniModalView;

namespace SanjivaniDataLinkLayer.CPDashBorad
{
   
    public  class ImpCPDashboard:InfCPDashBoard
    {
        DBConnection objcon = new DBConnection();

        public List<ChennelpartnerModel> getCPCustomerList(string CPCustID)
        {
            SqlCommand dinsert = new SqlCommand("");
            DataTable dtList = objcon.GetDtByCommand(dinsert);
            List<ChennelpartnerModel> list = new List<ChennelpartnerModel>();

            if (dtList.Rows.Count > 0)
            {
                foreach (DataRow dr in dtList.Rows)
                {
                    ChennelpartnerModel objChennelpartnerList = new ChennelpartnerModel();

                    objChennelpartnerList.StatusId = (dr["StatusId"].ToString());
                    objChennelpartnerList.chennelpartName = dr["CustName"].ToString();
                    objChennelpartnerList.mobileNo = dr["MobileNo"].ToString();
                    objChennelpartnerList.EmailID = dr["Email"].ToString();
                    objChennelpartnerList.CommanyName = dr["CompanyName"].ToString();
                    objChennelpartnerList.CustId = dr["CustId"].ToString();
                    objChennelpartnerList.CPId = dr["CPId"].ToString();

                    list.Add(objChennelpartnerList);
                }
            }
            return list;
        }

        public int getCpDashCount(string cPCustID)
        {
            SqlCommand dinsert1 = new SqlCommand("usp_CPDashboardCount");
           // dinsert1.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = CustID;
            var Result1 = objcon.GetExcuteScaler(dinsert1);
            return Result1;
        }
    }
}
