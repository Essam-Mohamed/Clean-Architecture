using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;

namespace BuberDinner.Domain.Guest.Entities
{
    public sealed class Rating : Entity<RatingId>
    {
        public HostId HostId { get; }
        public DinnerId DinnerId { get; }
        public int Value { get; }
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }

        private Rating(
            RatingId RatingId,
            HostId hostId,
            DinnerId dinnerId,
            int rating,
            DateTime createdDateTime,
            DateTime updatedDateTime)
            : base(RatingId)
        {
            HostId = hostId;
            DinnerId = dinnerId;
            Value = rating;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Rating Create(
            HostId hostId,
            DinnerId dinnerId,
            int rating)
        {
            return new(RatingId.CreateUnique(),
                hostId,
                dinnerId,
                rating,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }
    }
}
