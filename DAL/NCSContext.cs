using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;

namespace DAL;
public class NCSContext : Context
{
    public NCSContext()
    {
    }

    public NCSContext(DbContextOptions<NCSContext> options) : base(options) { }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySql("server=localhost;port=3306;user=root;database=ncs;", new MySqlServerVersion(new Version()));
        }
    }

    public override int SaveChanges()
    {
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries();

        entries.ToList().ForEach((entry) =>
        {

            if(entry.State == EntityState.Modified)
            {
                entry.Metadata.GetForeignKeyProperties().ToList().ForEach(propForeignKey =>
                {
                    var prop = entry.Property(propForeignKey.Name);

                    if(prop.CurrentValue != null)
                    {
                        if(int.TryParse(prop.CurrentValue.ToString(), out var value))
                        {
                            if(value == 0)
                            {
                                prop.IsModified = false;
                            }
                        }
                    }

                });
            }


        });

   

        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }
}
