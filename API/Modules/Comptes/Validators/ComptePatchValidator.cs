using API.Modules.Comptes.Ressources;
using DAL;

namespace API.Modules.Comptes.Validators;

public class ComptePatchValidator : AbstractValidator<ComptePatch>
{
    private NCSContext context;

    public ComptePatchValidator(NCSContext context)
    {
        this.context = context;

        RuleFor(comptePatch => comptePatch.Id)
            .NotEmpty()
            .NotNull()
            .NotEqual(0)
            .MustAsync(async (id, cancellation) => await this.context.Comptes.FindAsync(id) != null)
            .WithMessage("Le compte avec l'id fourni n'existe pas.");

        RuleFor(comptePatch => comptePatch.EstValider)
            .Must(estValider => estValider != "O" | estValider != "1")
            .WithMessage("La valeur `estValider` doit avoir pour valeur `O` ou `1`")
            .When(comptePatch => !string.IsNullOrEmpty(comptePatch.EstValider));

        RuleFor(comptePatch => comptePatch.NomEntreprise)
            .MinimumLength(1)
            .When(comptePatch => !string.IsNullOrEmpty(comptePatch.NomEntreprise));

        RuleFor(userSignup => userSignup.Prenom)
            .MinimumLength(1)
            .When(comptePatch => !string.IsNullOrEmpty(comptePatch.Prenom));

        RuleFor(comptePatch => comptePatch.Nom)
            .MinimumLength(1)
            .When(comptePatch => !string.IsNullOrEmpty(comptePatch.Nom));

        RuleFor(userSignup => userSignup.Mail)
           .EmailAddress()
           .When(comptePatch => !string.IsNullOrEmpty(comptePatch.Mail));

        RuleFor(comptePatch => comptePatch.Tel)
           .Length(10)
           .Matches(@"^[0-9]*$")
           .WithMessage("Le telephone ne doit pas contenir de lettres.")
           .When(comptePatch => !string.IsNullOrEmpty(comptePatch.Tel));

        RuleFor(comptePatch => comptePatch.AdresseFacturation)
            .MinimumLength(1)
            .When(comptePatch => !string.IsNullOrEmpty(comptePatch.AdresseFacturation));

        RuleFor(comptePatch => comptePatch.VilleFacturation)
            .MinimumLength(1)
            .When(comptePatch => !string.IsNullOrEmpty(comptePatch.VilleFacturation));

        RuleFor(userSignupRequest => userSignupRequest.Mail)
            .EmailAddress()
            .When(comptePatch => !string.IsNullOrEmpty(comptePatch.Mail));

        RuleFor(comptePatch => comptePatch.CodePostalFacturation)
            .Length(5)
            .Matches(@"^[0-9]*$")
            .WithMessage("Le code postal de facturation ne doit pas contenir de lettres.")
            .When(comptePatch => !string.IsNullOrEmpty(comptePatch.CodePostalFacturation));

        RuleFor(comptePatch => comptePatch.TelFacturation)
           .Length(10)
           .Matches(@"^[0-9]*$")
           .WithMessage("Le telephone de facturation ne doit pas contenir de lettres.")
           .When(comptePatch => !string.IsNullOrEmpty(comptePatch.TelFacturation));

        RuleFor(comptePatch => comptePatch.MailFacturation)
            .EmailAddress()
            .When(comptePatch => !string.IsNullOrEmpty(comptePatch.MailFacturation));

        RuleFor(comptePatch => comptePatch.ReductionPrix)
            .InclusiveBetween(0, 100)
            .When(comptePatch => comptePatch.ReductionPrix != null);
    }
}
