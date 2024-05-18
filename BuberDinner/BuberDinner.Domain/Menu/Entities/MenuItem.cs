using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Menu.Entities
{
    public sealed class MenuItem : Entity<MenuItemId>
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        private MenuItem() { }
        private MenuItem(MenuItemId menuItemId, string name, string desciption)
            : base(menuItemId)
        {
            Name = name;
            Description = desciption;
        }

        public static MenuItem Create(string name, string description)
        {
            return new(
                MenuItemId.CreateUnique(),
                name,
                description);
        }
    }
}
