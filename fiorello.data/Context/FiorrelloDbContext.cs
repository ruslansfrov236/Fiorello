using fiorello.entity.Entities;
using fiorello.entity.Entities.Customer;
using fiorello.entity.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fiorello.data.Context
{
	public class FiorrelloDbContext : IdentityDbContext<AppUser, AppRole, string>
	{
		public FiorrelloDbContext(DbContextOptions options) : base(options) { }

		public DbSet<Products> Products { get; set; }
		public DbSet<Header> Header { get; set; }
		public DbSet<Files> Files { get; set; }
		public DbSet<Category> Category { get; set; }	




		public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{


			var datas = ChangeTracker
				 .Entries<BaseEntity>();

			foreach (var data in datas)
			{
				_ = data.State switch
				{
					EntityState.Added => data.Entity.CreateDate = DateTime.UtcNow,
					EntityState.Modified => data.Entity.UpdateDate = DateTime.UtcNow,
					_ => DateTime.UtcNow
				};
			}

			return await base.SaveChangesAsync(cancellationToken);
		}

	}
}
