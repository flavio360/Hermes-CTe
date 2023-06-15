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

namespace HermesService.Domain.Service.PROC
{
    public class RecuperaFiliaisEmissorasAtivasSerivce : BaseService, IRecuperaFiliaisEmissorasAtivasSerivce
    {
        #region interfaces e Construtores
        readonly IEntrega_cte_conifg_filiais_emissorasRepository _Entrega_cte_conifg_filiais_emissorasRepository;

        public RecuperaFiliaisEmissorasAtivasSerivce(IEntityRepository repo, IEntrega_cte_conifg_filiais_emissorasRepository Entrega_cte_conifg_filiais_emissorasRepository) : base(repo)
        {
            _Entrega_cte_conifg_filiais_emissorasRepository = Entrega_cte_conifg_filiais_emissorasRepository;
        }
        #endregion

        public Entrega_cte_conifg_filiais_emissoras RecuperaFiliaisEmissorasAtivas(string cod_empresa)
        {
            using (DalSession dalSession = new DalSession())
            {
                UnitOfWork UoW = dalSession.UnitOfWork;

                try
                {
                    _Entrega_cte_conifg_filiais_emissorasRepository.InstanciarUnidade(UoW);
                    return _Entrega_cte_conifg_filiais_emissorasRepository.ConsultaEmissoraAtiva(cod_empresa);
                }
                catch (Exception ex )
                {

                    throw ex;
                }

            }
        }
    }
}


