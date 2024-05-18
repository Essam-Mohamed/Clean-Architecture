using BuberDinner.Domain.User;

namespace BuberDinner.Application.Authentications.Common
{
    public record AuthenticationResult(
        User User,
        string Token);
}
