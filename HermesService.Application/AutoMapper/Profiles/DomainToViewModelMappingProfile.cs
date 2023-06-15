using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using HermesService.Application.EntidadesDTO;
using HermesService.Domain.Entity.SICLONET;
using HermesService.Application.AutoMapper.TypeConvert.CTe;
using HermesService.Domain.Entity.SICLONET.PROC;

namespace HermesService.Application.AutoMapper.Profiles
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName => "DomainToViewModelMappingProfile";

        public DomainToViewModelMappingProfile()
        {
            CreateMap<IEnumerable<Entregas>, List<F_Insere_Fila_CTe>>().ConvertUsing<CTeTypeConverter>();
        }
    }
}
