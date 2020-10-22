using BandooDataLinkLayer;
using SanjivaniModalView;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanjivaniDataLinkLayer.Product
{
    public class ImpProduct : InfProduct
    {
        DBConnection objcon = new DBConnection();
        public List<ProductBusinessModal> getDoaminList(int catId)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetProduct");
            dinsert.Parameters.AddWithValue("@ProductCatId", SqlDbType.Int).Value = catId;
            DataSet dtList = objcon.GetDsByCommand(dinsert);
            List<ProductBusinessModal> list1 = new List<ProductBusinessModal>();
            foreach (DataRow dr in dtList.Tables[0].Rows)
            {
                ProductBusinessModal pd = new ProductBusinessModal();
                // BankDetails list1 = new BankDetails();
                pd.ProductId = Convert.ToInt32(dr["ProductId"].ToString());
                pd.ProductCode = dr["ProductCode"].ToString();
                pd.ProductName = dr["ProductName"].ToString();
                pd.ProductCatId = Convert.ToInt32(dr["ProductCatId"].ToString());
                pd.DomainERPCode = dr["DomainERPCode"].ToString();
                pd.DomainProviderCode = dr["DomainProviderCode"].ToString();
                pd.SACCode = dr["SACCode"].ToString();
                pd.RegistrartionPrice = (dr["RegistrartionPrice"].ToString());
                pd.RenewalPrice =(dr["RenewalPrice"].ToString());
                pd.TransferPrice = (dr["TransferPrice"].ToString());
                pd.DomainregistrationPrice =(dr["DomainregistrationPrice"].ToString());
                pd.PropductImage = (dr["PropductImage"].ToString());
                list1.Add(pd);

            }
            return list1;
        }
        public int setDomain(ProductBusinessModal pd)
        {
            SqlCommand dinsert = new SqlCommand("usp_SetProduct");
           
                dinsert.Parameters.AddWithValue("@ProductId", SqlDbType.Int).Value = pd.ProductId;
            if (pd.ProductName.ToString() != null)
                dinsert.Parameters.AddWithValue("@ProductName", SqlDbType.VarChar).Value = pd.ProductName;
           
                dinsert.Parameters.AddWithValue("@ProductCatId", SqlDbType.Int).Value = 1;
            if (!string.IsNullOrWhiteSpace(pd.DomainERPCode))
                dinsert.Parameters.AddWithValue("@DomainERPCode", SqlDbType.VarChar).Value = pd.DomainERPCode;
            if (!string.IsNullOrWhiteSpace(pd.DomainProviderCode))
                dinsert.Parameters.AddWithValue("@DomainProviderCode", SqlDbType.VarChar).Value = pd.DomainProviderCode;
            if (!string.IsNullOrWhiteSpace(pd.SACCode))
                dinsert.Parameters.AddWithValue("@SACCode", SqlDbType.VarChar).Value = pd.SACCode;
           
                dinsert.Parameters.AddWithValue("@RegistrartionPrice", SqlDbType.Decimal).Value = Convert.ToDecimal(pd.RegistrartionPrice);
            dinsert.Parameters.AddWithValue("@TransferPrice", SqlDbType.Decimal).Value = Convert.ToDecimal(pd.TransferPrice);
            dinsert.Parameters.AddWithValue("@RenewalPrice", SqlDbType.Decimal).Value = Convert.ToDecimal(pd.RenewalPrice);
            dinsert.Parameters.AddWithValue("@DomainregistrationPrice", SqlDbType.Decimal).Value = Convert.ToDecimal(pd.DomainregistrationPrice);
            if (!string.IsNullOrWhiteSpace(pd.PropductImage))
                dinsert.Parameters.AddWithValue("@PropductImage", SqlDbType.VarChar).Value = pd.PropductImage;
        
       
            var Result = objcon.GetExcuteScaler(dinsert);
            return Result;

        }

        public ProductBusinessModal getProductById(int productId)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetProductById");
            dinsert.Parameters.AddWithValue("@ProductId", SqlDbType.Int).Value = productId;
            DataSet DsList = objcon.GetDsByCommand(dinsert);
            ProductBusinessModal List = new ProductBusinessModal();
            if(DsList.Tables[0].Rows.Count>0)
            {
                if (DsList.Tables[0].Rows[0] != null)
                {

                    List.ProductId = Convert.ToInt32(DsList.Tables[0].Rows[0]["ProductId"]);
                    List.ProductCode = (DsList.Tables[0].Rows[0]["ProductCode"].ToString());
                    List.ProductName = DsList.Tables[0].Rows[0]["ProductName"].ToString();
                    List.DomainERPCode = DsList.Tables[0].Rows[0]["DomainERPCode"].ToString();
                    List.DomainProviderCode = DsList.Tables[0].Rows[0]["DomainProviderCode"].ToString();
                    List.SACCode = DsList.Tables[0].Rows[0]["SACCode"].ToString();
                    List.RegistrartionPrice = (DsList.Tables[0].Rows[0]["RegistrartionPrice"].ToString());
                    List.RenewalPrice = (DsList.Tables[0].Rows[0]["RenewalPrice"].ToString());
                    List.TransferPrice = (DsList.Tables[0].Rows[0]["TransferPrice"].ToString());
                    List.DomainregistrationPrice = (DsList.Tables[0].Rows[0]["DomainregistrationPrice"].ToString());

                }
            }
            
            return List;
        }
        public bool DeleteProduct(int productId)
        {
            SqlCommand dinsert1 = new SqlCommand("usp_DeleteProduct");
            dinsert1.Parameters.AddWithValue("@ProductId", SqlDbType.Int).Value = productId;
            bool Result1 = objcon.InsrtUpdtDlt(dinsert1);
            return Result1;
        }
    }
}
