using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Modules.Statuttransports;
public static class StatuttransportSeeder
{
    public static EntityTypeBuilder<Statuttransport> Seed(this EntityTypeBuilder<Statuttransport> entity)
    {
        entity.HasData(
            new Statuttransport { Id = 1, Nom = "En attente de validation", CouleurHex = "#323E40" },
            new Statuttransport { Id = 2, Nom = "Planifié", CouleurHex = "#F2A922" },
            new Statuttransport { Id = 3, Nom = "En cours", CouleurHex = "#D98014" },
            new Statuttransport { Id = 4, Nom = "Terminé", CouleurHex = "#367334" },
            new Statuttransport { Id = 5, Nom = "Annulé", CouleurHex = "#A62929" },
            new Statuttransport { Id = 6, Nom = "Expiré", CouleurHex = "#BF926B" }
        );

        return entity;
    }
}
