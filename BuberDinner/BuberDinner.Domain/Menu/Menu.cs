using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.Entities;
using BuberDinner.Domain.Menu.Events;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.MenuReview.ValueObjects;

namespace BuberDinner.Domain.Menu
{
    public sealed class Menu : AggregateRoot<MenuId>
    {
        private readonly List<MenuSection> _sections = new();
        private readonly List<DinnerId> _dinnerIds = new();
        private readonly List<MenuReviewId> _menuReviewIds = new();


        public string Name { get; private set; }
        public string Description { get; private set; }
        public AverageRating? AverageRating { get; private set; }
        public List<MenuSection> Sections => _sections;
        public List<DinnerId> DinnerIds => _dinnerIds;
        public List<MenuReviewId> MenuReviewIds => _menuReviewIds;
        public HostId HostId { get; private set; }
        public DateTime CreatedDateTime { get; private set; }
        public DateTime UpdatedDateTime { get; private set; }

        private Menu() { }
        private Menu(MenuId menuId,
            string name,
            string description,
            HostId hostId,
            List<MenuSection> sections,
            DateTime createdDateTime,
            DateTime updatedDateTime)
            : base(menuId)
        {
            Name = name;
            Description = description;
            HostId = hostId;
            _sections = sections;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }
        public static Menu Create(
            string name,
            string description,
            HostId hostId,
            List<MenuSection>? sections = null)
        {
            var menu = new Menu(
                MenuId.CreateUnique(),
                name,
                description,
                hostId,
                sections ?? new(),
                DateTime.UtcNow,
                DateTime.UtcNow);

            menu.AddDomainEvent(new MenuCreated(menu));
            return menu;
        }
    }
}
