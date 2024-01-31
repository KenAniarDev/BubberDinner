using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinners.ValueObjects;
using BuberDinner.Domain.Hosts.ValueObjects;
using BuberDinner.Domain.Ratings.ValueObjects;

namespace BuberDinner.Domain.Ratings;

public sealed class Rating : AggregateRoot<RatingId, Guid> 
{
    public HostId HostId { get; }
    public DinnerId DinnerId { get; }
    public int Rate { get; }
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; }
    
    private Rating(RatingId id, HostId hostId, DinnerId dinnerId, int rate, DateTime createdAt, DateTime updatedAt) : base(id)
    {
        HostId = hostId;
        DinnerId = dinnerId;
        Rate = rate;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }
    
    public static Rating Create(HostId hostId, DinnerId dinnerId, int rate)
    {
        return new(RatingId.CreateUnique(), hostId, dinnerId, rate, DateTime.UtcNow, DateTime.UtcNow);
    }
}