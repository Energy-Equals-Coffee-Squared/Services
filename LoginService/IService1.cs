using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace LoginService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        void GetData();

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        [OperationContract]
        DataSet LoginCheck(string UserNameEmail, string Password);//login function
        [OperationContract]
        string User_Register(User_Details userInfo);//register function

        [OperationContract]
        string AddProduct(Product_details ProductDetails);

        [OperationContract]
        string UpdateProduct(Product_details ProductDetails, int ProductID);
        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }

    }

    public class User_Details
    {
        //Variables
        string UserName = string.Empty;
        string Email = string.Empty;
        string First_Name = string.Empty;
        string Last_Name = string.Empty;
        string Password = string.Empty;
        string ContactNumber = string.Empty; 
        DateTime CreatedAt = DateTime.MinValue;
        DateTime UpdatedAt = DateTime.MinValue;
        bool IsActive = false;
        bool IsAdmin = false;
        bool IsDeleted = false;



        //Getter And Setter
        [DataMember]
        public string FirstName
        {
            get { return First_Name; }
            set { First_Name = value; }
        }
        [DataMember]
        public string LastName
        {
            get { return Last_Name; }
            set { Last_Name = value; }
        }
        [DataMember]
        public string email
        {
            get { return Email; }
            set { Email = value; }
        }
        [DataMember]
        public string contactnumber
        {
            get { return ContactNumber; }
            set { ContactNumber = value; }
        }
        [DataMember]
        public string Pass
        {
            get { return Password; }
            set { Password = value; }
        }
        [DataMember]
        public string userName
        {
            get { return UserName; }
            set { UserName = value; }
        }

        //DateTime CreatedAt = DateTime.MinValue;
        [DataMember]
        public DateTime created_at
        {
            get { return CreatedAt; }
            set { CreatedAt = value; }
        }
        //DateTime UpdatedAt = DateTime.MinValue;
        [DataMember]
        public DateTime updated_at
        {
            get { return UpdatedAt; }
            set { UpdatedAt = value; }
        }
        //bool IsActive = false;
        [DataMember]
        public bool isActive
        {
            get { return IsActive; }
            set { IsActive = value; }
        }
        //bool IsAdmin = false;
        [DataMember]
        public bool isAdmin
        {
            get { return IsAdmin; }
            set { IsAdmin = value; }
        }
        //bool isDeleted = false;
        [DataMember]
        public bool isDeleted
        {
            get { return IsDeleted; }
            set { IsDeleted = value; }
        }
    }

    public class Product_details
    {
        string name = string.Empty;
        string desc = string.Empty;
        string region = string.Empty;
        string roast = string.Empty;
        string altitude_max = string.Empty;
        string altitude_min = string.Empty;
        DateTime created_at = DateTime.MinValue;
        DateTime updated_at = DateTime.MinValue;
        bool isDeleted = false;
        string bean_type = string.Empty;

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        public string Description
        {
            get { return desc; }
            set { desc = value; }
        }

        [DataMember]
        public string Region
        {
            get { return region; }
            set { region = value; }
        }

        [DataMember]
        public string Roast
        {
            get { return roast; }
            set { roast = value; }
        }

        [DataMember]
        public string AltitudeMax
        {
            get { return altitude_max; }
            set { altitude_max = value; }
        }

        [DataMember]
        public string AltitudeMin
        {
            get { return altitude_min; }
            set { altitude_min = value; }
        }

        [DataMember]
        public DateTime CreatedAt
        {
            get { return created_at; }
            set { created_at = value; }
        }

        [DataMember]
        public DateTime UpdatedAt
        {
            get { return updated_at; }
            set { updated_at = value; }
        }

        [DataMember]
        public bool IsDeleted
        {
            get { return isDeleted; }
            set { isDeleted = value; }
        }

        [DataMember]
        public string BeanType
        {
            get { return bean_type; }
            set { bean_type = value; }
        }


    }
}
