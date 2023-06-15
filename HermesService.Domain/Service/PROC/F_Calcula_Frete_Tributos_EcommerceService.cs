using HermesService.Domain.Context;
using HermesService.Domain.Entity;
using HermesService.Domain.Entity.SICLONET.PROC;
using HermesService.Domain.Interfaces.Repositories.Entity.SICLONET.PROC;
using HermesService.Domain.Interfaces.Services.PROC;
using HermesService.Domain.Service.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace HermesService.Domain.Service
{
    public class F_Calcula_Frete_Tributos_EcommerceService : BaseService, IF_Calcula_Frete_Tributos_EcommerceService
    {
        #region Construtor e Interfaces
        private readonly IF_Calcula_Frete_Tributos_EcommerceRepository _F_Calcula_Frete_Tributos_Ecommerce;

        public F_Calcula_Frete_Tributos_EcommerceService(IEntityRepository repo, IF_Calcula_Frete_Tributos_EcommerceRepository F_Calcula_Frete_Tributos_Ecommerce) : base(repo)
        {
            _F_Calcula_Frete_Tributos_Ecommerce = F_Calcula_Frete_Tributos_Ecommerce;
        }
        #endregion
        public F_Calcula_Frete_Tributos_Ecommerce CalculaExpressaService(string codentregacli, string estado_origem, string estado_destino, string cod_ibge_destino, string cod_ibge_origem)
        {

            using (DalSession dalSession = new DalSession())
            {
                UnitOfWork UoW = dalSession.UnitOfWork;
                try
                {
                    _F_Calcula_Frete_Tributos_Ecommerce.InstanciarUnidade(UoW);
                    var ret = _F_Calcula_Frete_Tributos_Ecommerce.CalculaExpressa(codentregacli, estado_origem, estado_destino, cod_ibge_destino, cod_ibge_origem);
                    return ret;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
