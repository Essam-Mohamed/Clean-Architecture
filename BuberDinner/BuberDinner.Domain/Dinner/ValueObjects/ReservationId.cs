﻿using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Dinner.ValueObjects
{
    public sealed class ReservationId : ValueObject
    {
        public Guid Value { get; }
        private ReservationId(Guid value)
        {
            Value = value;
        }

        public static ReservationId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
        public override IEnumerable<object> GetEqualityComponent()
        {
            yield return Value;
        }
    }
}
