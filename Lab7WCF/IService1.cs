using Lab7WCF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Lab7WCF
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        Method = "POST",
        UriTemplate = "AddStore")]
        bool AddStore(Store store);

        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        Method = "POST",
        UriTemplate = "AddStaff")]
        bool AddStaff(Staff staff);

        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        Method = "GET",
        UriTemplate = "GetStaffs")]
        List<Staff> GetStaffs();

        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        Method = "GET",
        UriTemplate = "GetStores")]
        List<Store> GetStores();

        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        Method = "GET",
        UriTemplate = "GetStoreStaffs")]
        List<StoreStaff> GetStoreStaffs();
    }

}
