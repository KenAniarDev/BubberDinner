using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Dinners.ValueObjects;

public sealed class Status : ValueObject
{
    public string Value { get; }
    
    public static Status Upcoming() => new("Upcoming");

    public static Status InProgress() => new("Progress");

    public static Status Ended() => new("Ended");

    public static Status Cancelled() => new("Cancelled");
                           
    public Status(string value)
    {
        Value = value;
    }
                               
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
