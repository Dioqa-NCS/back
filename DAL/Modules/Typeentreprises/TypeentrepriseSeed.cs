using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Modules.Typeentreprises;
public static class TypeentrepriseSeed
{
    public static EntityTypeBuilder<Typeentreprise> Seed(this EntityTypeBuilder<Typeentreprise> entity)
    {
        entity.HasData(
                    new Typeentreprise { Id = 1, Nom = "EL / EIRL" },
                    new Typeentreprise { Id = 2, Nom = "EURL" },
                    new Typeentreprise { Id = 3, Nom = "SARL" },
                    new Typeentreprise { Id = 4, Nom = "SA" },
                    new Typeentreprise { Id = 5, Nom = "SAS / SASU" },
                    new Typeentreprise { Id = 6, Nom = "SNC" },
                    new Typeentreprise { Id = 7, Nom = "Scop" },
                    new Typeentreprise { Id = 8, Nom = "SCA" },
                    new Typeentreprise { Id = 9, Nom = "SCS" }
                );

        return entity;
    }
}
