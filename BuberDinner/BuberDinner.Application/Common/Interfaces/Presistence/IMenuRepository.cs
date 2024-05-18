using BuberDinner.Domain.Menu;

namespace BuberDinner.Application.Common.Interfaces.Presistence
{
    public interface IMenuRepository
    {
        void Add(Menu menu);
    }
}
