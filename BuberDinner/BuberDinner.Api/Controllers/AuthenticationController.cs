using BuberDinner.Application.Authentications.Commands.Register;
using BuberDinner.Application.Authentications.Common;
using BuberDinner.Application.Authentications.Queries.Login;
using BuberDinner.Contracts.Authentication;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    [Route("auth")]
    [AllowAnonymous]
    public class AuthenticationController : ApiController
    {
        private readonly ISender _mediatr;
        private readonly IMapper _mapper;

        public AuthenticationController(ISender mediatr, IMapper mapper)
        {
            _mediatr = mediatr;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = _mapper.Map<RegisterCommand>(request);
            ErrorOr<AuthenticationResult> authResult = await _mediatr.Send(command);

            return authResult.Match(
                authResult => Ok(_mapper.Map<AuthenticationResult, AuthenticationResponse>(authResult)),
                errors => Problem(errors));
        }



        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query = _mapper.Map<LoginQuery>(request);
            var authResult = await _mediatr.Send(query);

            // for specifice condition
            //if (authResult.IsError  && authResult.FirstError == Errors.Authentication.InvalidCredantials)
            //{
            //    return Problem(statusCode: StatusCodes.Status401Unauthorized, title: authResult.FirstError.Description);
            //}

            return authResult.Match(
                authResult => Ok(_mapper.Map<AuthenticationResult, AuthenticationResponse>(authResult)),
                errors => Problem(errors));
        }

        //=>One Of =>
        //[HttpPost("register")]
        //public IActionResult Register(RegisterRequest request)
        //{
        //    OneOf<AuthenticationResult, IError> registerResult = _authenticationService.Register(
        //        request.FirstName,
        //        request.LastName,
        //        request.Email,
        //        request.Password
        //        );
        //    return registerResult.Match(
        //        authResult => Ok(MapAuthResult(authResult)),
        //        error => Problem(title: error.ErrorMessage, statusCode: (int)error.StatusCode)
        //        );
        //    //AuthenticationResponse response = MapAuthResult(registerResult.AsT0);
        //    //return Ok(response);
        //}



        //Fulent Result =>
        //[HttpPost("register")]
        //public IActionResult Register(RegisterRequest request)
        //{
        //    Result<AuthenticationResult> registerResult = _authenticationService.Register(
        //        request.FirstName,
        //        request.LastName,
        //        request.Email,
        //        request.Password
        //        );
        //    if (registerResult.IsSuccess)
        //    {
        //        return Ok(MapAuthResult(registerResult.Value));
        //    }

        //    var firstError = registerResult.Errors[0];
        //    if (firstError is DublicationEmailError)
        //    {
        //        return Problem(statusCode: StatusCodes.Status409Conflict, title: "Email Exsits");
        //    }
        //    return Problem();
        //    //AuthenticationResponse response = MapAuthResult(registerResult.AsT0);
        //    //return Ok(response);
        //}
    }
}
