using AutoMapper;
using HermesService.Application.AutoMapper.TypeConvert.CTe;
using HermesService.Application.EntidadesDTO;
using HermesService.Domain.Entity.EntidadesDTO;
using HermesService.Domain.Entity.SICLONET;

namespace HermesService.Application.AutoMapper.Profiles.ViewToView
{
    public class ViewModelToViewModelXmlCTe : Profile
    {
        public override string ProfileName => "ViewModelToViewModelXmlCTeMappingProfile";

        public ViewModelToViewModelXmlCTe()
        {
            CreateMap<Entregas_cte_dados_gerados_detalhe, IdeDTO>().ConvertUsing<XmlCTeTypeConvert>();
            CreateMap<Entregas_cte_dados_gerados_detalhe, DestDTO>().ConvertUsing<XmlCTeTypeConvert>();
            CreateMap<Entregas_cte_dados_gerados_detalhe, RemDTO>().ConvertUsing<XmlCTeTypeConvert>();
            CreateMap<Entregas_cte_dados_gerados_detalhe, ExpedDTO>().ConvertUsing<XmlCTeTypeConvert>();
            CreateMap<Entregas_cte_dados_gerados_detalhe, EmitDTO>().ConvertUsing<XmlCTeTypeConvert>();
            CreateMap<Entregas_cte_dados_gerados_detalhe, VPrestDTO>().ConvertUsing<XmlCTeTypeConvert>();
            CreateMap<Entregas_cte_dados_gerados_detalhe, ImpDTO>().ConvertUsing<XmlCTeTypeConvert>();
        }
    }
}
