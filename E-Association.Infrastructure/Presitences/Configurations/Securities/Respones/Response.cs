using System.Net;

namespace Presitences.Configurations.Securities.Respones
{
    public class Response<T>
    {
        public bool Successed { set; get; }
        public string Message { set; get; }
        public HttpStatusCode StatusCode { set; get; }
        public object metaData { set; get; }
        public T Data { set; get; }
        public List<string> Errors { set; get; }
        public Response()
        {

        }
        public Response(string _message)
        {
            Successed = false;
            Message = _message;
        }
        public Response(string _messgae, bool _successed)
        {
            Successed = _successed;
            Message = _messgae;
        }
        public Response(T type, string _message = null)
        {
            Successed = true;
            Message = _message;
            Data = type;
        }
    }
}
