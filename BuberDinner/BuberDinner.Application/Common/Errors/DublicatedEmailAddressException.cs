using System.Net;

namespace BuberDinner.Application.Common.Errors
{
    public class DublicatedEmailAddressException : Exception, IServiceException
    {
        public HttpStatusCode StatusCode => HttpStatusCode.Conflict;

        public string ErrorMessage => "Email Already Exsits!";
    }
}
