using API.Modules.Comptes.Ressources;

namespace API.Modules.Typeentreprises.Ressources;

public class TypeentrepriseResponse
{
    public int Id { get; set; }

    public string Nom { get; set; }

    public IEnumerable<CompteResponse> Comptes { get; set; }
}
