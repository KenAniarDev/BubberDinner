using BuberDinner.Domain.Bills.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinners.ValueObjects;
using BuberDinner.Domain.Guests.ValueObjects;
using BuberDinner.Domain.MenuReviews.ValueObjects;
using BuberDinner.Domain.Ratings.ValueObjects;
using BuberDinner.Domain.User.ValueObjects;

namespace BuberDinner.Domain.Guests;

public sealed class Guest : AggregateRoot<GuestId, Guid>
{
    public readonly List<DinnerId> _upcomingDinnerIds = new();
    public readonly List<DinnerId> _pastDinnerIds = new();
    public readonly List<DinnerId> _pendingDinnerIds = new();
    public readonly List<BillId> _billIds = new();
    public readonly List<MenuReviewId> _menuReviewIds = new();
    public readonly List<RatingId> _ratings = new();
    
    public string FirstName { get; }
    public string LastName { get; }
    public string ProfileImage { get; }
    public double AverageRating { get; }
    public UserId UserId { get; }
    
    public IReadOnlyList<DinnerId> UpcomingDinnerIds => _upcomingDinnerIds.AsReadOnly();
    public IReadOnlyList<DinnerId> PastDinnerIds => _pastDinnerIds.AsReadOnly();
    public IReadOnlyList<DinnerId> PendingDinnerIds => _pendingDinnerIds.AsReadOnly();
    public IReadOnlyList<BillId> BillIds => _billIds.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
    public IReadOnlyList<RatingId> Ratings => _ratings.AsReadOnly();
    
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; }
    
    private Guest(GuestId id, string firstName, string lastName, string profileImage, double averageRating, UserId userId, DateTime createdAt, DateTime updatedAt) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        AverageRating = averageRating;
        UserId = userId;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }
    public static Guest Create(string firstName, string lastName, string profileImage, double averageRating, UserId userId)
    {
        return new(GuestId.CreateUnique(), firstName, lastName, profileImage, averageRating, userId, DateTime.UtcNow, DateTime.UtcNow);
    }
}