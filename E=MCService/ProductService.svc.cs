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

        public bool AddNewproduct(ProductClass product)
        {
            var newProduct = new product
            {
                name = product.name,
                desc = product.desc,
                region = product.region,
                roast = product.roast,
                altitude_max = product.altitude_max,
               // altitude_min = product.altitude_min,
                created_at = product.created_at,
                updated_at = product.updated_at,
                isDeleted = Convert.ToBoolean(product.isDeleted),
                bean_type = product.bean_type

      
            };
            db.products.InsertOnSubmit(newProduct);
            try
            {
                db.SubmitChanges();
                return true;
            } catch (Exception e)
            {
                e.GetBaseException();
                return false;
            }
        }

        public bool EditProduct(ProductClass product, string id)
        {
            var prod = (from x in db.products
                        where x.Id.Equals(id)
                        select x).FirstOrDefault();

            prod.name = product.name;
            prod.desc = product.desc;
            prod.region = product.region;
            prod.roast = product.roast;
            prod.altitude_max = product.altitude_max;
            // prod.altitude_min = product.altitude_min;
            prod.created_at = product.created_at;
            prod.updated_at = product.updated_at;
            prod.isDeleted = Convert.ToBoolean(product.isDeleted);
            prod.bean_type = product.bean_type;

            try
            {
                db.SubmitChanges();
                return true;
            }
            catch (IndexOutOfRangeException e)
            {
                e.GetBaseException();
                return false;
            }

        }

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
                isDeleted = Convert.ToBoolean(product.isDeleted),
                bean_type = product.bean_type
            };

            return PC;
        }
    }
}
