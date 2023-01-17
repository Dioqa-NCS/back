using API.Modules.Auth.Ressources;

namespace API.Modules.Auth.Mapping;

public class SignupRequestProfile : Profile
{
    public SignupRequestProfile()
    {
        this.CreateMap<SignupRequest, Compte>()
            .ForMember(opt => opt.EstValider, option => option.MapFrom(src => "O"))
            .ForMember(opt => opt.IdRoleCompte, option => option.MapFrom(src => 1))
            .ForMember(otp => otp.MailFacturation, option => option.MapFrom(src => string.IsNullOrEmpty(src.MailFacturation) ? src.Email : src.MailFacturation))
            .ForMember(opt => opt.TelFacturation, option => option.MapFrom(src => string.IsNullOrEmpty(src.TelFacturation) ? src.Tel : src.TelFacturation))
            .ForAllMembers(opt => opt.AllowNull());
    }
}
