using FluentResults;

namespace BuberDinner.Application.Common.Errors
{
    public class DublicationEmailError : IError //IError => interface idefined
    {
        //public HttpStatusCode StatusCode => HttpStatusCode.Conflict;

        //public string ErrorMessage => "Email Aready Exists!";

        public List<IError> Reasons => throw new NotImplementedException();

        public string Message => throw new NotImplementedException();

        public Dictionary<string, object> Metadata => throw new NotImplementedException();
    }
}
