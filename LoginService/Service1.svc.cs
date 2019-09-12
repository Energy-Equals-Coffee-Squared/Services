using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace LoginService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        SqlCommand CMD;
        SqlConnection connect;
        SqlConnectionStringBuilder conString;
        public void GetData()
        {
            //create new sql connection
            connect = new SqlConnection();
            //set the connection string
            connect.ConnectionString = "Data Source=(localdb)\v12.0;Initial Catalog=IFM2GroupPrac;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";
            //open the connection
            connect.Open();
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
        //login function that checks the users info it will return a table if there is a match if not it will return a table that has no info
        public DataSet LoginCheck(string UserNameEmail, string Password)
        {
            GetData();
            SqlDataAdapter sqlAdapter = new SqlDataAdapter("SELECT * FROM [Users] WHERE password = '" + Password + "' AND (email = '" + UserNameEmail + "' OR username = '" + UserNameEmail + "'"
                //set the source for data
                , @"Data Source = (localdb)\v12.0; Initial Catalog = IFM2GroupPrac; Integrated Security = True;");
            //create data table of selected user
            DataSet DS = new DataSet();

            connect.Open();

            sqlAdapter.Fill(DS);
            return DS;
        }



        //insert below into buton click for checking of login validity once all connected will make it work proper

        //localhost.Service1 obj = new localhost.Service1();
        //DataSet ds = obj.login(TextBox1.Text, TextBox2.Text);
        //if (ds.Tables[0].Rows.Count > 0)
        // {
        //  Label1.Text = "Hi ," + ds.Tables[0].Rows[0][1].ToString();
        //    //redirect
        // }
        // else
        // {
        //  Label1.Text = "Invalid UserName or Password.";
        // }


        public string User_Register(User_Details userInfo)
        {
            string UserDetails = string.Empty;

            //command for insterting into DB
            SqlCommand Command = new SqlCommand("INSERT INTO [Users](username, email, first_name, last_name, password, contact_number, created_at, updated_at, isActive, isAdmin, isDeleted) " +
                                                            "VALUES(@username, @email, @first_name, @last_name, @password, @contact_number, @created_at, @updated_at, @isActive, @isAdmin, @isDeleted)", connect);

            //write values to DB
            Command.Parameters.AddWithValue(" @username", userInfo.userName);
            Command.Parameters.AddWithValue("@email", userInfo.email);
            Command.Parameters.AddWithValue("@first_name", userInfo.FirstName);
            Command.Parameters.AddWithValue("@last_name", userInfo.LastName);
            Command.Parameters.AddWithValue("@password",userInfo.Pass);
            Command.Parameters.AddWithValue("@contact_number", userInfo.contactnumber);
            Command.Parameters.AddWithValue("@created_at", userInfo.created_at);
            Command.Parameters.AddWithValue("@updated_at",userInfo.updated_at);
            Command.Parameters.AddWithValue("@isActive",userInfo.isActive);
            Command.Parameters.AddWithValue("@isAdmin",userInfo.isAdmin);
            Command.Parameters.AddWithValue("@isDeleted",userInfo.isDeleted);
            //open connection to db
            GetData();

            Command.ExecuteNonQuery();

            

            return UserDetails;
        }

        public string AddProduct(Product_details ProductDetails)
        {
            SqlCommand Command = new SqlCommand("INSERT INTO [products](name, desc, region, roast, altitude_max, altitude_min, created_at, updated_at, isDeleted, bean_type) " +
                                                            "VALUES(@name, @desc, @region, @roast, @altitude_max, @altitude_min, @created_at, @updated_at, @isDeleted, @bean_type)", connect);

            //write values to DB
            Command.Parameters.AddWithValue(" @name", ProductDetails.Name);
            Command.Parameters.AddWithValue("@desc", ProductDetails.Description);
            Command.Parameters.AddWithValue("@region", ProductDetails.Region);
            Command.Parameters.AddWithValue("@roast", ProductDetails.Roast);
            Command.Parameters.AddWithValue("@altitude_max", ProductDetails.AltitudeMax);
            Command.Parameters.AddWithValue("@altitude_min", ProductDetails.AltitudeMin);
            Command.Parameters.AddWithValue("@created_at", ProductDetails.CreatedAt);
            Command.Parameters.AddWithValue("@updated_at", ProductDetails.UpdatedAt);
            Command.Parameters.AddWithValue("@isDeleted", ProductDetails.IsDeleted);
            Command.Parameters.AddWithValue("@bean_type", ProductDetails.BeanType);
          
            //open connection to db
            GetData();

            Command.ExecuteNonQuery();

            string ProdDetails = string.Empty;

            return ProdDetails;
        }

        public string UpdateProduct(Product_details ProductDetails, int ProductID)
        {
            String Message = "";

            SqlCommand Command = new SqlCommand("UPDATE [products] SET (name =@name , desc=@desc, region=@region, roast=@roast, altitude_max=@altitude_max, altitude_min=@altitude_min, " +
                                                                          "created_at=@created_at, updated_at=@created_at, isDeleted=@isDeleted, bean_type=@bean_type) " +
                                                                          "WHERE id = @id" , connect);

            //write values to DB
            Command.Parameters.AddWithValue("@id", ProductID);
            Command.Parameters.AddWithValue(" @name", ProductDetails.Name);
            Command.Parameters.AddWithValue("@desc", ProductDetails.Description);
            Command.Parameters.AddWithValue("@region", ProductDetails.Region);
            Command.Parameters.AddWithValue("@roast", ProductDetails.Roast);
            Command.Parameters.AddWithValue("@altitude_max", ProductDetails.AltitudeMax);
            Command.Parameters.AddWithValue("@altitude_min", ProductDetails.AltitudeMin);
            Command.Parameters.AddWithValue("@created_at", ProductDetails.CreatedAt);
            Command.Parameters.AddWithValue("@updated_at", ProductDetails.UpdatedAt);
            Command.Parameters.AddWithValue("@isDeleted", ProductDetails.IsDeleted);
            Command.Parameters.AddWithValue("@bean_type", ProductDetails.BeanType);

            //open connection to db
            GetData();

            Command.ExecuteNonQuery();

            return Message;
        }





        //found better method for login

        //public bool LoginCheck(string UserNameEmail, string Password)
        //{
        //    //get required data
        //    GetData();

        //    //create command for SQL table
        //    SqlCommand command = new SqlCommand();
        //    //create command to be able to send command to DB
        //    command = connect.CreateCommand();

        //    //send command to DB
        //    command.CommandText = "SELECT username, email, password FROM [Users]";

        //    command.Connection = connect;
        //    //create data reader to read values from DB
        //    SqlDataReader sqlDataReader = command.ExecuteReader();

        //    //create usertable
        //    User userTable = new User();

        // bool logincheck = false;

        //    //check to see if values arre empty
        //    if (string.IsNullOrEmpty(UserNameEmail))
        //    {
        //        throw new ArgumentNullException("UserMail is Empty");
        //    }
        //    if (string.IsNullOrEmpty(Password))
        //    {
        //        throw new ArgumentNullException("Password is Empty");
        //    }

        //    while (sqlDataReader.Read())
        //    {
        //        if (sqlDataReader[1].ToString() != UserNameEmail || sqlDataReader[1].ToString() != Password)
        //        {
        //            logincheck = false;
        //        }
        //        else
        //        {
        //            logincheck = true;
        //        }
        //    }

        //    return logincheck;
        //}

    }
}
