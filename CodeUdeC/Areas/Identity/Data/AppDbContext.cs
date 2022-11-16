using CodeUdeC.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Xml;

namespace CodeUdeC.Areas.Identity.Data;

//DB Conexion Context
public class AppDbContext : IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new ApplicacionUserEntityConfiguration());
    }

    //Use Entities For migrations
    public DbSet<CommentEntity> Comments { get; set; }
    public DbSet<MessageEntity> Messages { get; set; }
    public DbSet<ProjectEntity> Projects { get; set; }
    public DbSet<ViewsEntity> Views { get; set; }
    public DbSet<UpdateEntity> Updates { get; set; }
    public DbSet<ContributorEntity> Contributors { get; set; }
}

//Configuere User Entity
internal class ApplicacionUserEntityConfiguration : IEntityTypeConfiguration<AppUser>
{
    void IEntityTypeConfiguration<AppUser>.Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.Property(u => u.FirstName).HasMaxLength(120);
        builder.Property(u => u.LastName).HasMaxLength(120);
    }
}