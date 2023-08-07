using DarkmoomSession.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DarkmoomSession.DAL.Configuration.EntityConfiguration;

public class UsersConfiguration:IEntityTypeConfiguration<Users>
{
    public void Configure(EntityTypeBuilder<Users> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name);
        builder.Property(x => x.Password);
        builder.Property(x => x.Role);
    }
}