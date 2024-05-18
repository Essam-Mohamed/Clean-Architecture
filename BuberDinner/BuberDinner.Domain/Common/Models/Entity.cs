namespace BuberDinner.Domain.Common.Models
{
    public abstract class Entity<TId> : IEquatable<Entity<TId>>, IHasDomainEvents
        where TId : notnull
    {
        private readonly List<IDomainEvent> _domainEvents = new();

        public TId Id { get; protected set; }
        protected Entity(TId id)
        {
            Id = id;
        }

        protected Entity() { }

        public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        public override bool Equals(object? obj)
            => obj is Entity<TId> entity && Id.Equals(entity.Id);

        public bool Equals(Entity<TId>? other)
            => Equals((object?)other);

        public static bool operator ==(Entity<TId> left, Entity<TId> right)
            => Equals(left, right);

        public static bool operator !=(Entity<TId> left, Entity<TId> right)
            => !Equals(left, right);

        public override int GetHashCode()
            => Id.GetHashCode();

        public void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }
        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }
    }
}
