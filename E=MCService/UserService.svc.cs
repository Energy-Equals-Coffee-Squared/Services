using E_MCService.App_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace E_MCService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class UserService : IUser
    {

        //change the dataTable context to the required databse that is used
        DataTableDataContext db = new DataTableDataContext();

        

        //check is is valid user
        public int Login(string userName, string passWord)
        {
            
            var user = (from u in db.Users
                        where u.email.Equals(userName) || u.email.Equals(userName) &&
                        u.isActive.Equals(1) &&

                        u.password.Equals(EncryptionClass.HashPassword(passWord))//encryopt hash the password 
                      
                        select u).FirstOrDefault();

            //return user id if exists
            if (user != null)
            {
                return user.Id;
            }
            //return 0 if user does not exist
            else
            {
                return 0;
            }
        }

        //create new user
        public int Register(UserClass user)
        {
            var newUser = new User
            {
                username = user.username,
                email = user.email,
                first_name = user.first_name,
                last_name = user.last_name,
                password = EncryptionClass.HashPassword(user.password),//hash the password for storage
                contact_number = user.contact_number,
                created_at = user.created_at,
                updated_at = user.updated_at,
                isActive = user.isActive,
                isAdmin = user.isAdmin,
                isDeleted = user.isDeleted
            };
            //submit to db
            db.Users.InsertOnSubmit(newUser);

            try
            {
                db.SubmitChanges();
                return 1;
            }
            catch (Exception e)
            {
                e.GetBaseException();
                return -1;
            }

        }
    }
}
