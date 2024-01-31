using BuberDinner.Domain.Dinners.ValueObjects;
using BuberDinner.Domain.Hosts.ValueObjects;
using BuberDinner.Domain.Menu;
using BuberDinner.Domain.Menus.Entities;
using BuberDinner.Domain.Menus.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuberDinner.Infratrasture.Persistance.Configurations;

public class MenuConfigurations : IEntityTypeConfiguration<Menu>
{
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        ConfigureMenusTable(builder);
        // ConfigureMenuSectionsTable(builder);
        // ConfigureMenuDinnerIdsTable(builder);
        // ConfigureMenuReviewIdsTable(builder);
    }


    private void ConfigureMenusTable(EntityTypeBuilder<Menu> builder)
    {
        builder.ToTable("menus");
        builder.HasKey(menu => menu.Id);
    
        // Use HasConversion for value objects
        // builder.Property(menu => menu.Id)
        //     .HasColumnName("menu_id");  // Assuming your database column name is 'menu_id'
        //
        // builder.Property(menu => menu.Name)
        //     .HasMaxLength(100);
        //
        // builder.Property(menu => menu.Description)
        //     .HasMaxLength(1000);
        //
        // builder.OwnsOne(menu => menu.AverageRating);

        // builder.OwnsOne(menu => menu.HostId, hostId =>
        // {
        //     hostId.Property(h => h.Value)
        //         .HasColumnName("host_id");  // Assuming your database column name is 'host_id'
        // });
    }

    private void ConfigureMenuSectionsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(menu => menu.MenuSections, msb =>
        {
            msb.ToTable("menu_sections");
            msb.WithOwner().HasForeignKey("menu_id");
            
            msb.HasKey("id", "menu_id");
            msb.Property(ms => ms.Id)
                .HasColumnName("id")
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value, 
                    value => MenuSectionId.Create(value));
            
            msb.Property(ms => ms.Name)
                .HasMaxLength(100);
            
            msb.Property(ms => ms.Description)
                .HasMaxLength(100);

            msb.OwnsMany(ms => ms.MenuItems, mib =>
            {
                mib.ToTable("menu_items");

                mib.WithOwner().HasForeignKey("menu_section_id", "menu_id");

                mib.HasKey("id", "menu_section_id");
            });
            
            msb.Navigation(s => s.MenuItems).Metadata.SetField("_items");
            msb.Navigation(s => s.MenuItems).UsePropertyAccessMode(PropertyAccessMode.Field);

            
        });
    }
    
    
    private void ConfigureMenuReviewIdsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(menu => menu.ReviewIds, db =>
        {
            db.ToTable("menu_review_ids");
            db.WithOwner().HasForeignKey("menu_id");
            db.HasKey("id");

            db.Property(d => d.Value)
                .HasColumnName("review_id")
                .ValueGeneratedNever();

        });

        builder.Metadata.FindNavigation(nameof(Menu.ReviewIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureMenuDinnerIdsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(menu => menu.DinnerIds, db =>
        {
            db.ToTable("menu_dinner_ids");
            db.WithOwner().HasForeignKey("menu_id");
            db.HasKey("id");

            db.Property(d => d.Value)
                .HasColumnName("dinner_id")
                .ValueGeneratedNever();

        });

        builder.Metadata.FindNavigation(nameof(Menu.DinnerIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
    
}