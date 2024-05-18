using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Common.ValueObjects
{
    public sealed class Rating : ValueObject
    {
        public int Value { get; }
        private Rating(int value)
        {
            Value = value;
        }

        public static Rating Create(int rating = 0)
        {
            return new(rating);
        }

        public override IEnumerable<object> GetEqualityComponent()
        {
            yield return Value;
        }
    }
}
