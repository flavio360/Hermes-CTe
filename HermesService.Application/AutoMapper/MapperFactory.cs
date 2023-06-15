using AutoMapper;
using HermesService.Application.AutoMapper.Profiles;
using HermesService.Application.AutoMapper.Profiles.ViewToView;
using System;
using System.Collections.Generic;
using System.Text;

namespace HermesService.Application.AutoMapper
{
    public static class MapperFactory
    {
        public enum Processo
        {
            FILACTE = 0,
            ERROCTE = 1,
            XMLCTE  = 2
        }

        public static IMapper Mapper { get; private set; }

        public static void CarregaMapper(Processo processo)
        {
            CarregaPerfil(processo);
        }

        #region Perfis
        private static void CarregaPerfil(Processo processo)
        {
            switch (processo)
            {
                case Processo.FILACTE:
                    Mapper = DadosCte();
                break;

                case Processo.ERROCTE:
                    Mapper = DadosErroCte();
                break;

                case Processo.XMLCTE:
                    Mapper = XmlCte();
                break;
            }
        }
        #endregion

        #region Metodos
        private static IMapper DadosCte()
        {
            var dtoConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DomainToViewModelMappingProfile>();
            });
            Mapper mapper = new Mapper(dtoConfig);

            return mapper;
        }

        private static IMapper DadosErroCte()
        {
            var dtoConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ViewModelToViewModel>();
            });
            Mapper mapper = new Mapper(dtoConfig);

            return mapper;
        }

        private static IMapper XmlCte()
        {
            var dtoConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ViewModelToViewModelXmlCTe>();
            });
            Mapper mapper = new Mapper(dtoConfig);

            return mapper;
        }

        #endregion
    }
}
