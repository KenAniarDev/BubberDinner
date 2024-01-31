using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.User.ValueObjects;

namespace BuberDinner.Domain.User;

public sealed class User : AggregateRoot<UserId, Guid>
{
    public string FirstName { get; }
    public string LastName { get; }
    public string Email { get; }
    public string Password { get; }
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; }
    
    private User(UserId id, string firstName, string lastName, string email, string password, DateTime createdAt, DateTime updatedAt) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }
    
    public static User Create(string firstName, string lastName, string email, string password)
    {
        return new(UserId.CreateUnique(), firstName, lastName, email, password, DateTime.UtcNow, DateTime.UtcNow);
    }
}