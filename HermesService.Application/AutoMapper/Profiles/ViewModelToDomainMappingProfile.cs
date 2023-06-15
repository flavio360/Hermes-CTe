using AutoMapper;
using HermesService.Application.AutoMapper.TypeConvert.CTe;
using HermesService.Application.EntidadesDTO;
using HermesService.Domain.Entity.SICLONET;
using HermesService.Domain.Entity.SICLONET.PROC;
using System;
using System.Collections.Generic;
using System.Text;

namespace HermesService.Application.AutoMapper.Profiles
{
    class ViewModelToDomainMappingProfile : Profile
    {       
        public override string ProfileName => "ViewModelToDomainMappingProfile";

        public ViewModelToDomainMappingProfile()
        {
            CreateMap<List<F_Insere_Fila_CTe>, List<Entregas_cte_erro>>().ConvertUsing<CteErroTypeConverter>();
        }
    }
}
