using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmailApp.Context
{
	public class AppDbContext : IdentityDbContext<Entities.AppUser, Entities.AppRole, int>
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			// Gönderilen mesajlar
			builder.Entity<Entities.AppUser>()
				.HasMany(u => u.SentMessages)
				.WithOne(m => m.Sender)
				.HasForeignKey(m => m.SenderId)
				.OnDelete(DeleteBehavior.Restrict);  // ❗ Cascade kapalı

			// Alınan mesajlar
			builder.Entity<Entities.AppUser>()
				.HasMany(u => u.ReceivedMessages)
				.WithOne(m => m.Receiver)
				.HasForeignKey(m => m.ReceiverId)
				.OnDelete(DeleteBehavior.Restrict);  // ❗ Cascade kapalı

			base.OnModelCreating(builder);
		}

		public DbSet<Entities.Message> Messages { get; set; }

	}
}
