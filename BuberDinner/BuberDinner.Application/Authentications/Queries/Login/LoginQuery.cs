using BuberDinner.Application.Authentications.Common;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Authentications.Queries.Login
{
    public record LoginQuery(
        string Email,
        string Password) : IRequest<ErrorOr<AuthenticationResult>>;
}
