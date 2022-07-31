using AutoMapper;
using MobirollerTestProject.DataAccess.ApiHelperModels;
using MobirollerTestProject.DataAccess.Models;
using System.Collections.Generic;

namespace MobirollerTestProject.Api.MapperProfile.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TurkishHelperModel, Turkish>()
                .ForMember(destinationMember => destinationMember.Id, operation => operation.MapFrom(source => source.ID))
                .ForMember(destinationMember => destinationMember.DcKategori, operation => operation.MapFrom(source => source.Dc_Kategori))
                .ForMember(destinationMember => destinationMember.DcZaman, operation => operation.MapFrom(source => source.Dc_Zaman))
                .ForMember(destinationMember => destinationMember.DcOlay, operation => operation.MapFrom(source => source.Dc_Olay));

                    CreateMap<ItalianHelperModel, Italian>()
            .ForMember(destinationMember => destinationMember.Id, operation => operation.MapFrom(source => source.ID))
            .ForMember(destinationMember => destinationMember.DcCategoria, operation => operation.MapFrom(source => source.Dc_Categoria))
            .ForMember(destinationMember => destinationMember.DcOrario, operation => operation.MapFrom(source => source.Dc_Orario))
            .ForMember(destinationMember => destinationMember.DcEvento, operation => operation.MapFrom(source => source.Dc_Evento));
        }
    }
}
