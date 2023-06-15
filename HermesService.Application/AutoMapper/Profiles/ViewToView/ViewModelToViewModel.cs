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
    public class ViewModelToViewModel : Profile
    {
        public override string ProfileName => "ViewModelToViewModelProfile";
        public ViewModelToViewModel()
        {
            CreateMap<List<F_Insere_Fila_CTe>, List<Entregas_cte_erro>>().ConvertUsing<CteErroTypeConverter>();
        }
    }
}
