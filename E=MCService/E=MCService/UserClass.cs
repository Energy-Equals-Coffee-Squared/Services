using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_MCService
{
    public class UserClass
    {
        public int id;
        public string username;
        public string email;
        public string first_name;
        public string last_name;
        public string password;
        public string contact_number;
        public DateTime created_at;
        public DateTime updated_at;
        public byte isActive;
        public byte isAdmin;
        public byte isDeleted;
    }
}