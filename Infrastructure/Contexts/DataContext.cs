using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Entities;

namespace Infrastructure.Contexts;


public class DataContext : IdentityDbContext<UserEntity>
{
	public DataContext(DbContextOptions<DataContext> options)
		: base(options)
	{
	}




	public DbSet<AddressEntity> Addresses { get; set; }
	public DbSet<FeatureEntity> Features { get; set; }
	public DbSet<FeatureItemEntity> FeatureItems { get; set; }
	public DbSet<SubscriberEntity> Subscribers { get; set; }
	public DbSet<CourseEntity> Courses { get; set; }


	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);


		builder.Entity<UserEntity>()
			.HasOne(u => u.Address) 
			.WithOne() 
			.HasForeignKey<UserEntity>(u => u.AddressId) 
			.IsRequired(false);

        builder.Entity<CourseEntity>(entity =>
        {
            entity.Property(e => e.OriginalPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DiscountPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.LikesInProcent).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.LikesInNumbers).HasColumnType("decimal(18, 2)");
        });
    }
}

