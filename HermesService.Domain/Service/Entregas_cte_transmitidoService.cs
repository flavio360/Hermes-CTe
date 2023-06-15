using HermesService.Domain.Context;
using HermesService.Domain.Entity;
using HermesService.Domain.Entity.SICLONET;
using HermesService.Domain.Interfaces.Repositories.Entity.SICLONET;
using HermesService.Domain.Interfaces.Services;
using HermesService.Domain.Service.Base;
using HermesService.Domain.Utilities;
using HermesService.Domain.Utilities.Certificado;
using System;
using System.Collections.Generic;
using System.Text;

namespace HermesService.Domain.Service
{
    public class Entregas_cte_transmitidoService : BaseService, IEntregas_cte_transmitidoService
    {

        private readonly IEntregas_cte_transmitidoRepository _Entregas_cte_transmitido;
        public Entregas_cte_transmitidoService
        (
            IEntityRepository repo, IEntregas_cte_transmitidoRepository Entregas_cte_transmitido
        ) :base(repo)
        {
            _Entregas_cte_transmitido = Entregas_cte_transmitido;
        }

        public void TreatRecordResponseRecepcao(string xmlResponse, Entregas_cte_dados_gerados_detalhe dadosPedido=null)
        {
            using (DalSession dalSession = new DalSession())
            {
                UnitOfWork UoW = dalSession.UnitOfWork;

                _Entregas_cte_transmitido.InstanciarUnidade(UoW);
                var objReposnse = ResponseSefaz.StringToObjReceivedSefaz(xmlResponse, dadosPedido);

                var enumstatus = ((int)CTEEnums.STATUS_SEFAZ.LoteRecebido).ToString();

                if (objReposnse.cte_status == enumstatus)
                {
                    _Entregas_cte_transmitido.RecordResponse(objReposnse);
                }
            }
        }

        public IEnumerable<Entregas_cte_transmitido> SelectEntregas_cte_transmitido()
        {
            using (DalSession dalSession = new DalSession())
            {
                UnitOfWork UoW = dalSession.UnitOfWork;

               _Entregas_cte_transmitido.InstanciarUnidade(UoW);
               var ret = _Entregas_cte_transmitido.SelectEntregas_cte_transmitido();

               return ret;
            }
        }
        public void TreatRecordResponseRetRecepcao(Entregas_cte_transmitido xmlResponse)
        {
            using (DalSession dalSession = new DalSession())
            {
                UnitOfWork UoW = dalSession.UnitOfWork;
                _Entregas_cte_transmitido.InstanciarUnidade(UoW);
                _Entregas_cte_transmitido.UpdateCte(xmlResponse);
            }
        }
    }
}
