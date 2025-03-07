﻿#nullable disable

using API.Modules.Typeentreprises.Ressources;

namespace API.Modules.Comptes.Ressources;

public class CompteResponse
{
    public int Id { get; set; }

    public int IdTypeEntreprise { get; set; }

    public string Nom { get; set; }

    public string Prenom { get; set; }

    public string NomEntreprise { get; set; }

    public string Mail { get; set; }

    public string Tel { get; set; }

    public string EstValider { get; set; }

    public string MailFacturation { get; set; }

    public string AdresseFacturation { get; set; }

    public string ReductionPrix { get; set; }

    public string CodePostalFacturation { get; set; }

    public string VilleFacturation { get; set; }

    public string TelFacturation { get; set; }

    public TypeentrepriseResponse Typeentreprise { get; set; }
}
