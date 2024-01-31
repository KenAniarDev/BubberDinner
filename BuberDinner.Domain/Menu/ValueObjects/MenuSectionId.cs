using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Menus.ValueObjects;

public sealed class MenuSectionId : ValueObject
{
    public Guid Value { get; }
    
    private MenuSectionId(Guid value)
    {
        Value = value;
    }

    public static MenuSectionId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public static MenuSectionId Create(Guid value)
    {
        return new(value);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
#pragma warning disable CS8618
    private MenuSectionId() {}
#pragma warning restore CS8618
}