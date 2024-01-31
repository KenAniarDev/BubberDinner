using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinners.ValueObjects;
using BuberDinner.Domain.Guests.ValueObjects;
using BuberDinner.Domain.Hosts.ValueObjects;
using BuberDinner.Domain.MenuReviews.ValueObjects;
using BuberDinner.Domain.Menus.ValueObjects;

namespace BuberDinner.Domain.MenuReviews;

public sealed class MenuReview : AggregateRoot<MenuReviewId, Guid>
{
    public double Rating { get; }
    public string Comment { get; }
    public HostId HostId { get; }
    public MenuId MenuId { get; }
    public GuestId GuestId { get; }
    public DinnerId DinnerId { get; }
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; }
    
    private MenuReview(MenuReviewId id, double rating, string comment, HostId hostId, MenuId menuId, GuestId guestId, DinnerId dinnerId, DateTime createdAt, DateTime updatedAt) : base(id)
    {
        Rating = rating;
        Comment = comment;
        HostId = hostId;
        MenuId = menuId;
        GuestId = guestId;
        DinnerId = dinnerId;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }
    public static MenuReview Create(double rating, string comment, HostId hostId, MenuId menuId, GuestId guestId, DinnerId dinnerId)
    {
        return new(MenuReviewId.CreateUnique(), rating, comment, hostId, menuId, guestId, dinnerId, DateTime.UtcNow, DateTime.UtcNow);
    }
}