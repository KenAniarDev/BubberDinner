using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Application.Services.Authentication.Command.Domain.GuestRating.ValueObjects;

public class GuestRatingId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }
    
    private GuestRatingId(Guid value)
    {
        Value = value;
    }

    public static GuestRatingId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
