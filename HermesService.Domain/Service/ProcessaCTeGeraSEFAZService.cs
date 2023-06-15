using HermesService.Domain.Context;
using HermesService.Domain.Entity;
using HermesService.Domain.Entity.SICLONET;
using HermesService.Domain.Interfaces.Repositories.Entity.SICLONET;
using HermesService.Domain.Interfaces.Services;
using HermesService.Domain.Service.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HermesService.Domain.Service
{
    public class ProcessaCTeGeraSEFAZService : BaseService, IProcessaCTeGeraSEFAZService
    {
        #region Construtor e Interfaces
        private readonly IEntregas_cte_dados_gerados_detalheRepository _Entregas_cte_dados_gerados_detalhe;

        public ProcessaCTeGeraSEFAZService(IEntityRepository repo, IEntregas_cte_dados_gerados_detalheRepository ProcessaCTeGeraSEFAZ) : base(repo)
        {
            _Entregas_cte_dados_gerados_detalhe = ProcessaCTeGeraSEFAZ;
        }
        #endregion


        public List<Entregas_cte_dados_gerados_detalhe> DadosProcessoGeraCTe(string cod_empresa)
        {
           
            using (DalSession dalSession = new DalSession())
            {                
                UnitOfWork UoW = dalSession.UnitOfWork;
                
                try
                {
                    _Entregas_cte_dados_gerados_detalhe.InstanciarUnidade(UoW);
                    
                    return _Entregas_cte_dados_gerados_detalhe.RecuperaDadosProcessoGeraCTe(cod_empresa);
                }
                catch (Exception ex)
                {
                    throw new Exception("Problema ao recuperar pedidos para processo de montagem do XML do CTe | EX: " + ex.Message);
                }
            }
        }




    }
}
