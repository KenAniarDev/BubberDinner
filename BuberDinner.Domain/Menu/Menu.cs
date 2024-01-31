using BuberDinner.Application.Services.Authentication.Command.Domain.Common.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinners.ValueObjects;
using BuberDinner.Domain.Hosts.ValueObjects;
using BuberDinner.Domain.Menus.Entities;
using BuberDinner.Domain.Menus.ValueObjects;
using BuberDinner.Domain.MenuReviews.ValueObjects;

namespace BuberDinner.Domain.Menu
{
    public sealed class Menu : AggregateRoot<MenuId, Guid>
    {
        private readonly List<MenuSection> _sections = new();
        private readonly List<DinnerId> _dinnerIds = new();
        private readonly List<MenuReviewId> _reviews = new();
        public string Name { get; private set;}
        public string Description { get; private set;}
        public AverageRating AverageRating { get; private set;}

        public IReadOnlyList<MenuSection> MenuSections => _sections.AsReadOnly();
        public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
        public IReadOnlyList<MenuReviewId> ReviewIds => _reviews.AsReadOnly();

       // public HostId HostId { get; private set;}
        public DateTime CreatedAt { get; private set;}
        public DateTime UpdatedAt { get; private set;}

        private Menu(MenuId id, HostId hostId, string name, string description, List<MenuSection> sections, DateTime createdAt,
            DateTime updatedAt) : base(id)
        {
            Id = id;
            Name = name;
            Description = description;
            //HostId = hostId;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            _sections = sections;
            AverageRating = new AverageRating(5, 1);
        }

        public static Menu Create(HostId hostId, string name, string description, List<MenuSection> sections)
        {
            return new(MenuId.CreateUnique(), hostId, name, description, sections, DateTime.UtcNow,
                DateTime.UtcNow);
        }
        
        #pragma warning disable CS8618
        private Menu() {}
        #pragma warning restore CS8618
    }
}