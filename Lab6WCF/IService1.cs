using Lab6WCF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Lab6WCF
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            Method = "GET",
            UriTemplate = "findAll")]
        List<Book> findAll();

        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            Method = "POST",
            UriTemplate = "AddBook")]
        void AddBook(Book book);

        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            Method = "GET",
            UriTemplate = "findOne/{isbn}")]
        Book findOne(string isbn);

        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            Method = "PUT",
            UriTemplate = "updatedBook")]
        void updatedBook(Book book);

        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            Method = "DELETE",
            UriTemplate = "deleteBook/{isbn}")]
        bool deleteBook(string isbn);
    }
}
