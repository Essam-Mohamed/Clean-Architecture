using BuberDinner.Domain.User;

namespace BuberDinner.Application.Common.Interfaces.Presistence
{
    public interface IUserRepository
    {
        User? GetUserByEmail(string email);
        void Add(User user);
    }
}
