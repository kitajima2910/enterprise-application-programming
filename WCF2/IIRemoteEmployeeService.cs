using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCF2.Models;

namespace WCF2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IIRemoteEmployeeService" in both code and config file together.
    [ServiceContract]
    public interface IIRemoteEmployeeService
    {
        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        Method = "POST",
        UriTemplate = "PostEmployee")]
        bool PostEmployee(Employee employee);

        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        Method = "GET",
        UriTemplate = "GetEmployeesList")]
        List<Employee> GetEmployeesList();

        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        Method = "GET",
        UriTemplate = "GetEmployee/{id}")]
        Employee GetEmployee(string id);

        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        Method = "PUT",
        UriTemplate = "PutEmployee")]
        bool PutEmployee(Employee employee);
    }
}
