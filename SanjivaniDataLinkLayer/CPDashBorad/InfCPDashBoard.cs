using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SanjivaniModalView;

namespace SanjivaniDataLinkLayer.CPDashBorad
{
    public interface InfCPDashBoard
    {
        int getCpDashCount(string cPCustID);
      List<ChennelpartnerModel> getCPCustomerList(string CPCustID);
    }
}
