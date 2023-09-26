using HermesService.Domain.Context;
using HermesService.Domain.Entity;
using HermesService.Domain.Entity.SICLONET;
using HermesService.Domain.Interfaces.Repositories.Entity.SICLONET;
using HermesService.Domain.Interfaces.Services;
using HermesService.Domain.Service.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace HermesService.Domain.Service
{
    public class Cte_endereco_web_serviceService : BaseService, ICte_endereco_web_serviceService
    {
        #region interfaces e Construtores
        private readonly ICte_endereco_web_serviceRepository _Cte_endereco_web_service;
        public Cte_endereco_web_serviceService
        (
            IEntityRepository repo, ICte_endereco_web_serviceRepository Cte_endereco_web_service
        ) : base(repo)
        {
            _Cte_endereco_web_service = Cte_endereco_web_service;
        }
        #endregion
        public List<cte_endereco_web_service> ConsultaDadosWSSefaz()
        {
            using (DalSession dalSession = new DalSession())
            {
                UnitOfWork UoW = dalSession.UnitOfWork;

                _Cte_endereco_web_service.InstanciarUnidade(UoW);
                var objWS = _Cte_endereco_web_service.ConsultaDadosWSSefaz();

                return objWS;
            }           
        }
    }
}
