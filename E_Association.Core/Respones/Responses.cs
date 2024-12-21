using Microsoft.AspNetCore.Http;
using System.Net;

namespace Application.Respones
{
    public class Responses<T>
    {
        public bool Successed { set; get; }
        public string Message { set; get; }
        public HttpStatusCode StatusCode { set; get; }
        public object metaData { set; get; }
        public T Data { set; get; }
        public List<string> Errors {  set; get; }    
        public Responses()
        {

        }
        public Responses(string _message)
        {
            Successed = false;
            Message = _message;
        }
        public Responses(string _messgae,bool _successed)
        {
            Successed = _successed;
            Message = _messgae;
        }
        public Responses(T type,string _message = null)
        {
            Successed = true;
            Message = _message;
            Data = type;
        }
    }
}
