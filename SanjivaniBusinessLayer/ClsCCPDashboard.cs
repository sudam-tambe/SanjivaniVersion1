using SanjivaniDataLinkLayer.CPDashBorad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SanjivaniDataLinkLayer.CPDashBorad;
using SanjivaniModalView;

namespace SanjivaniBusinessLayer
{
  public  class ClsCCPDashboard
    {
        InfCPDashBoard objInfCPDash = new ImpCPDashboard();

        public int getCpDashCount(string CPCustID)
        {
            return objInfCPDash.getCpDashCount(CPCustID);
        }

        public  List<ChennelpartnerModel> GetCPCustomerList(string CPCustId)
        {
            return objInfCPDash.getCPCustomerList(CPCustId);
        }
    }
}
