using AutoMapper;

namespace Apes.SugarKingdom.Application.Profiles;

public class SugarProfile : Profile
{
    public SugarProfile() : base()
    {
        _ = CreateMap<Models.VersusPoints, Data.VersusPoints>()
            .ReverseMap();
    }
}
