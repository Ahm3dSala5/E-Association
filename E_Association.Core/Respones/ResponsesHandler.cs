using System.Net;

namespace Application.Respones
{
    public class ResponsesHandler
    {
        public Responses<T> Deleted<T>()
        {
            return new Responses<T>()
            {
                Successed = true,
                Message = "Deleted",
                StatusCode = HttpStatusCode.OK,
            };
        }
        public Responses<T> Created<T>(T data)
        {
            return new Responses<T>
            {
                StatusCode = HttpStatusCode.Created,
                Message = "Created",
                Successed = true,
            };
        }
        public Responses<T> NotFound<T>()
        {
            return new Responses<T>()
            {
                StatusCode = HttpStatusCode.NotFound,
                Successed = false ,
                Message = "Not Found",
            };
        }
        public Responses<T> Unauthorized<T>()
        {
            return new Responses<T>()
            {
                StatusCode = HttpStatusCode.Unauthorized,
                Successed = true,
                Message = "Not Found",
            };
        }

        public Responses<T> UnprocessableEntity<T>()
        {
            return new Responses<T>()
            {
                StatusCode = HttpStatusCode.UnprocessableEntity,
                Successed = false,
                Message = "UnprocessableEntity",
            };
        }

        public Responses<T> Success<T>()
        {
            return new Responses<T>()
            {
                StatusCode = HttpStatusCode.OK,
                Successed = true,
                Message = "Success",
            };
        }
    }
    
}
