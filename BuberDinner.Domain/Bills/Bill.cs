using BuberDinner.Application.Services.Authentication.Command.Domain.Common.ValueObjects;
using BuberDinner.Domain.Bills.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinners.ValueObjects;
using BuberDinner.Domain.Guests.ValueObjects;
using BuberDinner.Domain.Hosts.ValueObjects;

namespace BuberDinner.Domain.Bills;

public sealed class Bill : AggregateRoot<BillId, Guid>
{
    public DinnerId DinnerId { get; }
    public GuestId GuestId { get; }
    public HostId HostId { get; }
    public Price Price { get; }
    
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; }
    
    private Bill(BillId id, DinnerId dinnerId, GuestId guestId, HostId hostId, Price price, DateTime createdAt, DateTime updatedAt) : base(id)
    {
        DinnerId = dinnerId;
        GuestId = guestId;
        HostId = hostId;
        Price = price;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }
    public static Bill Create(DinnerId dinnerId, GuestId guestId, HostId hostId, Price price)
    {
        return new(BillId.CreateUnique(), dinnerId, guestId, hostId, price, DateTime.UtcNow, DateTime.UtcNow);
    }
}