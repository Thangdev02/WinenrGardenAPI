using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WinnerGardenAPI.Models;

public partial class WinnerGardenDbContext : DbContext
{
    public WinnerGardenDbContext()
    {
    }

    public WinnerGardenDbContext(DbContextOptions<WinnerGardenDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Blog> Blogs { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderProduct> OrderProducts { get; set; }

    public virtual DbSet<Plant> Plants { get; set; }

    public virtual DbSet<PlantRatingBreakdown> PlantRatingBreakdowns { get; set; }

    public virtual DbSet<PlantReview> PlantReviews { get; set; }

    public virtual DbSet<PlantSize> PlantSizes { get; set; }

    public virtual DbSet<PlantTag> PlantTags { get; set; }

    public virtual DbSet<PlantThumbnail> PlantThumbnails { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost,1433;Database=WinnerGardenDB;User Id=sa;Password=Thanglq123;Encrypt=False;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Blogs__3213E83F1064DE37");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AuthorId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("authorId");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.Image)
                .HasMaxLength(500)
                .HasColumnName("image");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");

            entity.HasOne(d => d.Author).WithMany(p => p.Blogs)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("FK__Blogs__authorId__5441852A");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Orders__3213E83FE02B57C9");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.Total).HasColumnName("total");
            entity.Property(e => e.UserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("userId");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Orders__userId__4CA06362");
        });

        modelBuilder.Entity<OrderProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderPro__3213E83F00B81386");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Image)
                .HasMaxLength(500)
                .HasColumnName("image");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.OrderId).HasColumnName("orderId");
            entity.Property(e => e.PlantId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("plantId");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderProducts)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__OrderProd__order__4F7CD00D");

            entity.HasOne(d => d.Plant).WithMany(p => p.OrderProducts)
                .HasForeignKey(d => d.PlantId)
                .HasConstraintName("FK__OrderProd__plant__5070F446");
        });

        modelBuilder.Entity<Plant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Plants__3213E83F84200FA0");

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Image)
                .HasMaxLength(500)
                .HasColumnName("image");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.OriginalPrice).HasColumnName("originalPrice");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.RatingCount).HasColumnName("ratingCount");
            entity.Property(e => e.Sku)
                .HasMaxLength(50)
                .HasColumnName("sku");
            entity.Property(e => e.StockStatus)
                .HasMaxLength(50)
                .HasColumnName("stockStatus");
        });

        modelBuilder.Entity<PlantRatingBreakdown>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PlantRat__3213E83F697D64E2");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Count).HasColumnName("count");
            entity.Property(e => e.PlantId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("plantId");
            entity.Property(e => e.Stars).HasColumnName("stars");

            entity.HasOne(d => d.Plant).WithMany(p => p.PlantRatingBreakdowns)
                .HasForeignKey(d => d.PlantId)
                .HasConstraintName("FK__PlantRati__plant__45F365D3");
        });

        modelBuilder.Entity<PlantReview>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PlantRev__3213E83F7D8AC272");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comment)
                .HasMaxLength(500)
                .HasColumnName("comment");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.PlantId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("plantId");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .HasColumnName("userName");

            entity.HasOne(d => d.Plant).WithMany(p => p.PlantReviews)
                .HasForeignKey(d => d.PlantId)
                .HasConstraintName("FK__PlantRevi__plant__4316F928");
        });

        modelBuilder.Entity<PlantSize>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PlantSiz__3213E83F75728A3B");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PlantId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("plantId");
            entity.Property(e => e.Size)
                .HasMaxLength(100)
                .HasColumnName("size");

            entity.HasOne(d => d.Plant).WithMany(p => p.PlantSizes)
                .HasForeignKey(d => d.PlantId)
                .HasConstraintName("FK__PlantSize__plant__3C69FB99");
        });

        modelBuilder.Entity<PlantTag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PlantTag__3213E83FB36BB00C");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PlantId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("plantId");
            entity.Property(e => e.Tag)
                .HasMaxLength(100)
                .HasColumnName("tag");

            entity.HasOne(d => d.Plant).WithMany(p => p.PlantTags)
                .HasForeignKey(d => d.PlantId)
                .HasConstraintName("FK__PlantTags__plant__3F466844");
        });

        modelBuilder.Entity<PlantThumbnail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PlantThu__3213E83F4A8E2789");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PlantId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("plantId");
            entity.Property(e => e.ThumbnailUrl)
                .HasMaxLength(500)
                .HasColumnName("thumbnailUrl");

            entity.HasOne(d => d.Plant).WithMany(p => p.PlantThumbnails)
                .HasForeignKey(d => d.PlantId)
                .HasConstraintName("FK__PlantThum__plant__398D8EEE");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3213E83F48897737");

            entity.HasIndex(e => e.Email, "UQ__Users__AB6E61643C502A78").IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.Avatar)
                .HasMaxLength(500)
                .HasColumnName("avatar");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
