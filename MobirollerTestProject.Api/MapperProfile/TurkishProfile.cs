using AutoMapper;
using MobirollerTestProject.DataAccess.ApiHelperModels;
using MobirollerTestProject.DataAccess.Models;

namespace MobirollerTestProject.Api.MapperProfile
{
    public class TurkishProfile : Profile
    {
        public TurkishProfile()
        {
            CreateMap<TurkishHelperModel, Turkish>()
                .ForMember(destinationMember => destinationMember.Id, operation => operation.MapFrom(source => source.ID))
                .ForMember(destinationMember => destinationMember.DcKategori, operation => operation.MapFrom(source => source.Dc_Kategori))
                .ForMember(destinationMember => destinationMember.DcZaman, operation => operation.MapFrom(source => source.Dc_Zaman))
                .ForMember(destinationMember => destinationMember.DcOlay, operation => operation.MapFrom(source => source.Dc_Olay));
        }
    }
}
