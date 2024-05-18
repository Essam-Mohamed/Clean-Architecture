using BuberDinner.Application.Authentications.Common;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Authentications.Commands.Register
{
    public record RegisterCommand(
        string FirstName,
        string LastName,
        string Email,
        string Password) : IRequest<ErrorOr<AuthenticationResult>>;
}
