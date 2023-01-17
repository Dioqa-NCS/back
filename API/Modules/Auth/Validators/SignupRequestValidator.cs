using API.Modules.Auth.Ressources;
using Microsoft.AspNetCore.Identity;

namespace API.Modules.Auth.Validators;

public class SignupRequestValidator : AbstractValidator<SignupRequest>
{
    private UserManager<Compte> userManager { get; set; }

    public SignupRequestValidator(UserManager<Compte> userManager)
    {
        this.userManager = userManager;


        RuleFor(userSignup => userSignup.IdTypeEntreprise).NotEmpty().NotNull();

        RuleFor(userSignup => userSignup.Nom).NotEmpty().NotNull();

        RuleFor(userSignup => userSignup.Prenom).NotEmpty().NotNull();

        RuleFor(userSignup => userSignup.Email)
            .NotEmpty()
            .NotNull()
            .EmailAddress();

        RuleFor(userSignup => userSignup.UserName)
            .NotEmpty()
            .NotNull()
            .EmailAddress()
            .Must((userSignup, userName) => !this.userManager.Users.Any(user => user.UserName == userName))
            .WithMessage("Le mail est déja existant.")
            .Must((userSignup, userName) => userSignup.Mail == userName)
            .WithMessage("Le user name et mail doivent correspondre.");


        RuleFor(userSignupRequest => userSignupRequest.Mail)
            .NotEmpty()
            .NotNull()
            .EmailAddress();

        RuleFor(userSignup => userSignup.MdpConfirmation)
            .NotEmpty()
            .NotNull()
            .MinimumLength(6)
            .Equal(userSignup => userSignup.Mdp);

        RuleFor(userSignup => userSignup.Mdp)
            .NotEmpty()
            .NotNull()
            .MinimumLength(6)
            .Equal(userSignup => userSignup.MdpConfirmation)
            .Matches(@"\d")
            .WithMessage("Le mot de passe dot contenir 1 chiffre.")
            .Matches(@".*[a-z].*")
            .WithMessage("Le mot de passe dot contenir 1 caractère minuscule.")
            .Matches(@".*[A-Z].*")
            .WithMessage("Le mot de passe dot contenir 1 caractère majuscule.");

        RuleFor(userSignup => userSignup.Tel)
            .NotNull()
            .NotEmpty()
            .Length(10)
            .Matches(@"^[0-9]*$")
            .WithMessage("Le telephone ne doit pas contenir de lettres.");

        RuleFor(userSignup => userSignup.AdresseFacturation)
            .NotNull()
            .NotEmpty();

        RuleFor(userSignup => userSignup.VilleFacturation)
            .NotEmpty()
            .NotNull();

        RuleFor(userSignupRequest => userSignupRequest.MailFacturation)
            .NotNull()
            .NotEmpty()
            .EmailAddress();

        RuleFor(userSignup => userSignup.TelFacturation)
            .Length(10)
            .Matches(@"^[0-9]*$")
            .WithMessage("Le telephone de facturation ne doit pas contenir de lettres.")
            .When(userSignup => !string.IsNullOrEmpty(userSignup.MailFacturation));

        RuleFor(userSignup => userSignup.CodePostalFacturation)
            .Length(5)
            .Matches(@"^[0-9]*$")
            .WithMessage("Le code postal de facturation ne doit pas contenir de lettres.");

        RuleFor(userSignup => userSignup.NomEntreprise)
            .NotEmpty()
            .NotNull();
    }
}
