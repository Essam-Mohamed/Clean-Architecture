﻿using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Bill.ValueObjects
{
    public sealed class BillId : ValueObject
    {
        public Guid Value { get; }
        private BillId(Guid value)
        {
            Value = value;
        }

        public static BillId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
        public override IEnumerable<object> GetEqualityComponent()
        {
            yield return Value;
        }
    }
}
