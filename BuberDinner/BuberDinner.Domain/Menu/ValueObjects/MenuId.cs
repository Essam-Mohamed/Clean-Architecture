﻿using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Menu.ValueObjects
{
    public sealed class MenuId : ValueObject
    {
        public Guid Value { get; }
        private MenuId(Guid value)
        {
            Value = value;
        }

        public static MenuId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public static MenuId Create(Guid value)
        {
            return new(value);
        }
        public override IEnumerable<object> GetEqualityComponent()
        {
            yield return Value;
        }
    }
}
