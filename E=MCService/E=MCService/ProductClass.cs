using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_MCService
{
    public class ProductClass
    {
      public string name;
        public string desc;
        public string region;
        public string roast;
        public string altitude_max;
        public string altitude_min;
        public DateTime created_at;
        public DateTime updated_at;
        public byte isDeleted;
        public string bean_type;
    }
}