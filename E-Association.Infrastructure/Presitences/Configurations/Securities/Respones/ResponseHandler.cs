namespace Presitences.Configurations.Securities.Respones
{
    public class ResponseHandler
    {
        public Response<T> Deleted<T>()
        {
            return new Response<T>()
            {
                Successed = true,
                //StatusCode = 
            };
        }
    }
}
