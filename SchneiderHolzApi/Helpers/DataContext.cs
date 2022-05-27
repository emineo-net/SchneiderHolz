namespace SchneiderHolzApi.Helpers;

using Microsoft.EntityFrameworkCore;
using SchneiderHolzApi.Entities;
using SchneiderHolzApi.Models;

public partial class DataContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
    }

    public DbSet<User> Users { get; set; }
    public virtual DbSet<TransportOrder> TransportOrders { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TransportOrder>(entity =>
        {
            entity.ToTable("transport_order");

            entity.Property(e => e.Generated)
                .HasColumnType("datetime")
                .HasColumnName("generated")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.Ignore).HasColumnName("ignore");

            entity.Property(e => e.Location)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("location")
                .HasDefaultValueSql("('')")
                .IsFixedLength();

            entity.Property(e => e.PackageNumber)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("package_number")
                .HasDefaultValueSql("('')");

            entity.Property(e => e.Position)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("position")
                .HasDefaultValueSql("('')")
                .IsFixedLength();

            entity.Property(e => e.Priority)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("priority")
                .HasDefaultValueSql("('')")
                .IsFixedLength();

            entity.Property(e => e.Source)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("source")
                .HasDefaultValueSql("('')")
                .IsFixedLength();

            entity.Property(e => e.Status)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("status")
                .HasDefaultValueSql("('')")
                .IsFixedLength();

            entity.Property(e => e.Target)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("target")
                .HasDefaultValueSql("('')")
                .IsFixedLength();

            entity.Property(e => e.Type)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("type")
                .HasDefaultValueSql("('')")
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);



}