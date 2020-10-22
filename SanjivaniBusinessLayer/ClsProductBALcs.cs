using SanjivaniDataLinkLayer.Product;
using SanjivaniModalView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanjivaniBusinessLayer
{
    public class ClsProductBALcs
    {
        InfProduct objInfPub = new ImpProduct();

        public List<ProductBusinessModal> GetDoaminList(int catId)
        {
            return objInfPub.getDoaminList(catId);
        }

        public int SetDomain(ProductBusinessModal pd)
        {
            return objInfPub.setDomain(pd);
        }

        public ProductBusinessModal GetProductById(int ProductId)
        {
            return objInfPub.getProductById(ProductId);
        }

        public bool deleteProduct(int productId)
        {
            return objInfPub.DeleteProduct(productId);
        }
    }
}
