using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCF.Models;

namespace WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMovieServices" in both code and config file together.
    [ServiceContract]
    public interface IMovieServices
    {
        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        Method = "POST",
        UriTemplate = "PostMovie")]
        bool PostMovie(Movie movie);

        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        Method = "GET",
        UriTemplate = "GetMoviesList")]
        List<Movie> GetMoviesList();

        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        Method = "DELETE",
        UriTemplate = "DeleteMovie/{id}")]
        bool DeleteMovie(string id);
    }
}
