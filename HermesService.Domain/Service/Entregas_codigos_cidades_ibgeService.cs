using HermesService.Domain.Context;
using HermesService.Domain.Entity;
using HermesService.Domain.Interfaces.Repositories.Entity.SICLONET;
using HermesService.Domain.Interfaces.Services;
using HermesService.Domain.Service.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace HermesService.Domain.Service
{
    public class Entregas_codigos_cidades_ibgeService : BaseService, IEntregas_codigos_cidades_ibgeService
    {
        #region Construtor e Interfaces
        private readonly IEntregas_codigos_cidades_ibgeRepository _Entregas_codigos_cidades_ibgeService;

        public Entregas_codigos_cidades_ibgeService(IEntityRepository repo, IEntregas_codigos_cidades_ibgeRepository FilaErroCteService) : base(repo)
        {
            _Entregas_codigos_cidades_ibgeService = FilaErroCteService;
        }
        #endregion


        public string  ObeterCodigoIBGE(string cidade, string uf)
        {
            string codIBGE = string.Empty;
            using (DalSession dalSession = new DalSession())
            {
                UnitOfWork UoW = dalSession.UnitOfWork;

                _Entregas_codigos_cidades_ibgeService.InstanciarUnidade(UoW);
                 codIBGE = _Entregas_codigos_cidades_ibgeService.ObeterCodigoIBGE(cidade, uf);

            }           
            return codIBGE;
        }
    }
}
