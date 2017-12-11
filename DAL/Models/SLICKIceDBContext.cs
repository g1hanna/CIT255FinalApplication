using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SLICKIce.Application.Models;

namespace SLICKIce.Application.Data
{
    public partial class SLICKIceDBContext : DbContext
    {
        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Item> Item { get; set; }

		public SLICKIceDBContext(DbContextOptions<SLICKIceDBContext> options) : base(options)
		{
			return;
		}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
				optionsBuilder.UseSqlServer(AppUtil.sqlserverConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.Entity<Account>(entity =>
			{
				entity.Property(e => e.AccountId)
					.HasColumnName("AccountID")
					.ValueGeneratedNever();

				entity.Property(e => e.AccountFirstName)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.AccountLastName)
					.HasMaxLength(70)
					.IsUnicode(false);

				entity.Property(e => e.AccountPassword)
					.HasMaxLength(70)
					.IsUnicode(false);

				entity.Property(e => e.AccountUsername)
					.HasMaxLength(50)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Inventory>(entity =>
			{
				entity.HasKey(e => new { e.AccountId, e.ItemId });

				entity.Property(e => e.AccountId).HasColumnName("AccountID");

				entity.Property(e => e.ItemId).HasColumnName("ItemID");

				entity.HasOne(d => d.Account)
					.WithMany(p => p.Inventory)
					.HasForeignKey(d => d.AccountId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_Inventory_Account");

				entity.HasOne(d => d.Item)
					.WithMany(p => p.Inventory)
					.HasForeignKey(d => d.ItemId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_Inventory_Item");
			});

			modelBuilder.Entity<Item>(entity =>
			{
				entity.Property(e => e.ItemId)
					.HasColumnName("ItemID")
					.ValueGeneratedOnAdd();

				entity.Property(e => e.ItemCondition).HasDefaultValueSql("((10))");

				entity.Property(e => e.ItemDescription)
					.HasMaxLength(200)
					.IsUnicode(false);

				entity.Property(e => e.ItemName)
					.IsRequired()
					.HasMaxLength(70)
					.IsUnicode(false)
					.HasDefaultValueSql("('')");

				entity.Property(e => e.ItemType).HasDefaultValueSql("((2))");
			});

			modelBuilder.Entity<Item>().HasKey(i => i.ItemId);
		}

		public override void Dispose() {
			base.Dispose();
		}
    }
}
