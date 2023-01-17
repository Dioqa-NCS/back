using Microsoft.EntityFrameworkCore;

namespace DAL;
public class NCSContext : DBContext
{
    public NCSContext( DbContextOptions<NCSContext> options ) : base( options ) { }


    public override int SaveChanges()
    {
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync( bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default )
    {
        var entries = ChangeTracker.Entries();
        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Modified)
            {
                entry.References.ToList().ForEach( foreignKeyProperty =>
                {
                    var fkValue = foreignKeyProperty.CurrentValue;
                    var propertyName = foreignKeyProperty.Metadata.Name;

                    if (fkValue == null)
                    {
                        entry.Reference( propertyName ).IsModified = false;
                    }

                    if (fkValue != null)
                    {
                        if (int.TryParse( fkValue.ToString(), out var value ))
                        {
                            if (value == 0)
                            {
                                entry.Reference( propertyName ).IsModified = false;
                            }
                        }
                    }
                });

            }
        }

        return base.SaveChangesAsync( acceptAllChangesOnSuccess, cancellationToken );
    }
}
