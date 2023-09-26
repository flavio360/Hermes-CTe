using Dapper;
using HermesService.Domain.Context;
using HermesService.Domain.Entity;
using HermesService.Domain.Entity.SICLONET;
using HermesService.Domain.Interfaces.Repositories.Entity.SICLONET;
using HermesService.Domain.Interfaces.Repositories.Entity.SICLONET.PROC;
using HermesService.Domain.Interfaces.Services;
using HermesService.Domain.Service.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace HermesService.Domain.Service
{
    public class FilaErroCteService : BaseService, IFilaErroCteService

    {

        #region Construtor e Interfaces
        private readonly IFilaErroCteRepository _FilaErroCteService;


        public FilaErroCteService(IEntityRepository repo, IFilaErroCteRepository FilaErroCteService) : base(repo)
        {
            _FilaErroCteService = FilaErroCteService;
        }


        #endregion


        public void GravaFilaErroCte(DynamicParameters entregas_Cte_Erros)
        {
            //#TODO Rever a ordem de instancia da sessao a base com o foreach

                //var objErro = new entregas_Cte_Erros();
            using (DalSession dalSession = new DalSession())
            {
                UnitOfWork UoW = dalSession.UnitOfWork;
                try
                {
                    _FilaErroCteService.InstanciarUnidade(UoW);

                    _FilaErroCteService.GravaFilaErroCte(entregas_Cte_Erros);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }            
        }

        public void GravaErroCte(string cod_entrega, string observacao_erro, string cod_cte_id = null)
        {
            using (DalSession dalSession = new DalSession())
            {
                UnitOfWork UoW = dalSession.UnitOfWork;
                try
                {
                    _FilaErroCteService.InstanciarUnidade(UoW);
                    _FilaErroCteService.GravaErroCte(cod_entrega, observacao_erro, cod_cte_id);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void F_processa_erro_cte(string data_processado, string cod_entrega, string status_cte)
        {
            using (DalSession dalSession = new DalSession())
            {
                UnitOfWork UoW = dalSession.UnitOfWork;
                try
                {
                    _FilaErroCteService.InstanciarUnidade(UoW);
                    _FilaErroCteService.F_processa_erro_cte(data_processado, cod_entrega, status_cte);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
