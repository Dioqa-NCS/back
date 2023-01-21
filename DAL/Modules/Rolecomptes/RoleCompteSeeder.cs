using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Modules.Rolecomptes;
public static class RoleCompteSeeder
{
    public static EntityTypeBuilder<Rolecompte> Seed(this EntityTypeBuilder<Rolecompte> entity) {

        entity.HasData(
            new Rolecompte { Id = 1, Nom = "Administrateur"},
            new Rolecompte { Id = 2, Nom = "Client" }
            );
        return entity;
    }
    
        
    
}
