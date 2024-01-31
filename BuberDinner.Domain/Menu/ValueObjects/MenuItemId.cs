﻿using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Menus.ValueObjects;

public class MenuItemId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }
    
    private MenuItemId(Guid value)
    {
        Value = value;
    }

    public static MenuItemId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
#pragma warning disable CS8618
    private MenuItemId() {}
#pragma warning restore CS8618
}