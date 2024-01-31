using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Application.Services.Authentication.Command.Domain.Common.ValueObjects;

public class AverageRating : ValueObject
{
    public decimal Value { get; private set; }
    public int NumberOfRatings { get; private set; }

    public AverageRating(decimal value, int numberOfRatings)
    {
        Value = value;
        NumberOfRatings = numberOfRatings;
    }
    

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
        yield return NumberOfRatings;
    }
}