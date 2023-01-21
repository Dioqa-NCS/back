using DAL.Modules;

namespace DAL.Modules.Adresses;
public class AdresseRepository : Repository<Adresse, int>, IAdresseRepository
{
    public AdresseRepository(NCSContext Context) : base(Context) { }
}
