#nullable disable

using API.Modules.Comptes.Ressources;

namespace API.Modules.Typeentreprises.Ressources;

public partial class TypeentrepriseResponse
{
    public int Id { get; set; }

    public string Nom { get; set; }

    public IEnumerable<CompteResponse> Comptes { get; set; }
}
