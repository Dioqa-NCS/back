using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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
            optionsBuilder.UseMySql("server=bef4oahbww6ootvomeaw-mysql.services.clever-cloud.com;port=3306;pwd=RgUEHpzjVM8Q7OxXFsx1;user=unq6tuny3kxylule;database=bef4oahbww6ootvomeaw;", new MySqlServerVersion(new Version()));
        }
    }


    public override int SaveChanges()
    {
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries();
        foreach(var entry in entries)
        {
            if(entry.State == EntityState.Modified)
            {
                entry.References.ToList().ForEach(foreignKeyProperty =>
                {
                    var fkValue = foreignKeyProperty.CurrentValue;
                    var propertyName = foreignKeyProperty.Metadata.Name;

                    if(fkValue == null)
                    {
                        entry.Reference(propertyName).IsModified = false;
                    }

                    if(fkValue != null)
                    {
                        if(int.TryParse(fkValue.ToString(), out var value))
                        {
                            if(value == 0)
                            {
                                entry.Reference(propertyName).IsModified = false;
                            }
                        }
                    }
                });

            }
        }

        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }
}
