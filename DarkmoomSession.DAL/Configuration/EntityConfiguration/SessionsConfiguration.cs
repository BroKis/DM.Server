using DarkmoomSession.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DarkmoomSession.DAL.Configuration.EntityConfiguration;

public class SessionsConfiguration:IEntityTypeConfiguration<Sessions>
{
    public void Configure(EntityTypeBuilder<Sessions> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name);
        builder.Property(x => x.Token);
        builder.Property(x => x.UserId);
    }
}