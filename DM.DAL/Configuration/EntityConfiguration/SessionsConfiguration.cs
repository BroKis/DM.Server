using DM.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DM.DAL.Configuration.EntityConfiguration;

/// <summary>
/// Class for configuration Session entity in database
/// </summary>
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