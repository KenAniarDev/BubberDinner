using BuberDinner.Application.Services.Authentication.Command.Domain.Common.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinners.ValueObjects;
using BuberDinner.Domain.Hosts.ValueObjects;
using BuberDinner.Domain.Menus.ValueObjects;
using BuberDinner.Domain.Reservation.ValueObjects;

namespace BuberDinner.Application.Services.Authentication.Command.Domain.Dinner;

public sealed class Dinner : Entity<DinnerId>
{
    private readonly List<ReservationId> _reservations = new();
    public string Name { get; }
    public string Description { get; }
    public DateTime StartDateTime { get; }
    public DateTime EndDateTime { get; }
    public DateTime StartedDateTime { get; }
    public DateTime EndedDateTime { get; }
    public Status Status { get; }
    public bool IsPublic { get; }
    public int MaxGuests { get; }
    public Price Price { get; }
    public HostId HostId { get; }
    public MenuId MenuId { get; }
    public string ImageUrl { get; }
    public Location Location { get; }
    
    public IReadOnlyList<ReservationId> Reservations => _reservations.AsReadOnly();
    
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; }
    
    private Dinner(DinnerId id, string name, string description, DateTime startDateTime, DateTime endDateTime, Status status, bool isPublic, int maxGuests, Price price, HostId hostId, MenuId menuId, string imageUrl, Location location, DateTime createdAt, DateTime updatedAt) : base(id)
    {
        Name = name;
        Description = description;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        Status = status;
        IsPublic = isPublic;
        MaxGuests = maxGuests;
        Price = price;
        HostId = hostId;
        MenuId = menuId;
        ImageUrl = imageUrl;
        Location = location;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }
    
    public static Dinner Create(string name, string description, DateTime startDateTime, DateTime endDateTime, Status status, bool isPublic, int maxGuests, Price price, HostId hostId, MenuId menuId, string imageUrl, Location location)
    {
        return new(DinnerId.CreateUnique(), name, description, startDateTime, endDateTime, status, isPublic, maxGuests, price, hostId, menuId, imageUrl, location, DateTime.UtcNow, DateTime.UtcNow);
    }
}