using E_MCService.App_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace E_MCService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ProductService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ProductService.svc or ProductService.svc.cs at the Solution Explorer and start debugging.
    public class ProductService : IProductService
    {
        DataTableDataContext db = new DataTableDataContext();

        public int FindProduct(string name)
        {
            var FoundPart = (from p in db.products
                             where p.name.Equals(name)
                             select p).FirstOrDefault();

            if (FoundPart != null)
            {
                return FoundPart.Id;
            }
            else
            {
                return 0;
            }
        }

        public ProductClass GetProduct(string ID)
        {
            var product = (from p in db.products
                             where p.Id.Equals(ID)
                             select p).FirstOrDefault();

            ProductClass PC = new ProductClass
            {
                name = product.name,
                desc = product.desc,
                region = product.region,
                roast = product.roast,
                altitude_max = product.altitude_max,
                //not sure why its not picking up altitude min will check tomro
               // altitude_min = product.altitude_min,
                created_at = Convert.ToDateTime(product.created_at),
                updated_at = Convert.ToDateTime(product.updated_at),
                isDeleted = Convert.ToByte(product.isDeleted),
                bean_type = product.bean_type
            };

            return PC;
        }
    }
}
