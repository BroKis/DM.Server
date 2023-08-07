using DarkmoomSession.DAL.Configuration.ConnectionConfiguration;
using DarkmoomSession.DAL.Configuration.EntityConfiguration;
using DarkmoomSession.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DarkmoomSession.DAL.Application;

public class ApplicationContext:DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        :base(options)
    {
        
    }
    
    public ApplicationContext()
    {
        
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        if (!optionsBuilder.IsConfigured)
        {

            optionsBuilder.UseMySql(Connector.ConnectString(),
                ServerVersion.AutoDetect(Connector.ConnectString()));

        }
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        if (Database.IsRelational())
        {

            modelBuilder.ApplyConfiguration(new UsersConfiguration());
            modelBuilder.ApplyConfiguration(new SessionsConfiguration());
            
        }
    }
    
    public DbSet<Users> Users { get; set; }
    public DbSet<Sessions> Session { get; set; }
}