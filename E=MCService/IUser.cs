using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace E_MCService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IUser
    {

        [OperationContract]
        int Login(string userName, string passWord);
        [OperationContract]
        int Register(UserClass userClass);

        // TODO: Add your service operations here
    }


   
    
}
