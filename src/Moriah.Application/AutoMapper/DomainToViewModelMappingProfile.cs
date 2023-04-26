﻿using AutoMapper;
using Moriah.Application.ViewModels;
using Moriah.Domain.Entities;

namespace Moriah.Application.AutoMapper;

public class DomainToViewModelMappingProfile : Profile
{
    public DomainToViewModelMappingProfile()
    {
        CreateMap<Caixa, CaixaViewModel>()
            .PreserveReferences()
            .ForMember(x => x.Id, opt => opt.MapFrom(scr => scr.Id))
            .ForMember(x => x.Data, opt => opt.MapFrom(scr => scr.Data))
            .ForMember(x => x.Nota, opt => opt.MapFrom(scr => scr.Nota))
            .ForMember(x => x.Moeda, opt => opt.MapFrom(scr => scr.Moeda))
            .ForMember(x => x.Cartao, opt => opt.MapFrom(scr => scr.Cartao));
    }
}