using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace E_MCService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IProductService" in both code and config file together.
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        int FindProduct(String name);

        [OperationContract]
        ProductClass GetProduct(string ID);

        [OperationContract]
        bool AddNewproduct(ProductClass product);

        [OperationContract]
        bool EditProduct(ProductClass product, string id);
    }
}
