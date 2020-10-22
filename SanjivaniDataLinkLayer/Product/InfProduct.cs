using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SanjivaniModalView;

namespace SanjivaniDataLinkLayer.Product
{
    public interface InfProduct
    {
        List<ProductBusinessModal> getDoaminList(int catId);
        int setDomain(ProductBusinessModal pd);
        ProductBusinessModal getProductById(int productId);
        bool DeleteProduct(int productId);
    }
}
