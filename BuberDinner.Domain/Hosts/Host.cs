using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinners.ValueObjects;
using BuberDinner.Domain.Hosts.ValueObjects;
using BuberDinner.Domain.Menus;
using BuberDinner.Domain.Menus.ValueObjects;
using BuberDinner.Domain.User.ValueObjects;

namespace BuberDinner.Domain.Host;

public sealed class Host : AggregateRoot<HostId, Guid>
{
    public readonly List<MenuId> _menuIds = new();
    public readonly List<DinnerId> _dinnerIds = new();
    
    public string FirstName { get; }
    public string LastName { get; }
    public string ProfileImage { get; }
    public double AverageRating { get; }
    public UserId UserId { get; }
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; }
    
    private Host(HostId id, string firstName, string lastName, string profileImage, double averageRating, UserId userId, DateTime createdAt, DateTime updatedAt) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        AverageRating = averageRating;
        UserId = userId;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }
    
    public static Host Create(string firstName, string lastName, string profileImage, double averageRating, UserId userId)
    {
        return new(HostId.CreateUnique(), firstName, lastName, profileImage, averageRating, userId, DateTime.UtcNow, DateTime.UtcNow);
    }
}