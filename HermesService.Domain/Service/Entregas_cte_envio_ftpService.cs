using HermesService.Domain.Context;
using HermesService.Domain.Entity;
using HermesService.Domain.Entity.SICLONET;
using HermesService.Domain.Interfaces.Repositories;
using HermesService.Domain.Interfaces.Services;
using HermesService.Domain.Service.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace HermesService.Domain.Service
{
    public class Entregas_cte_envio_ftpService : BaseService, IEntregas_cte_envio_ftpService
    {
        private readonly IEntregas_cte_envio_ftpRepository _Entregas_cte_envio_ftp;
        public Entregas_cte_envio_ftpService
        (
            IEntityRepository repo, IEntregas_cte_envio_ftpRepository Entregas_cte_transmitido
        ) : base(repo)
        {
            _Entregas_cte_envio_ftp = Entregas_cte_transmitido;
        }

        public string Consulta_entregas_cte_envio_ftp(string cod_entrega, string chave_cte)
        {
            using (DalSession dalSession = new DalSession())
            {
                UnitOfWork UoW = dalSession.UnitOfWork;

                _Entregas_cte_envio_ftp.InstanciarUnidade(UoW);

                string xml = _Entregas_cte_envio_ftp.Consulta_entregas_cte_envio_ftp(cod_entrega, chave_cte);
                return xml;

            }
        }

        public void Update_entregas_cte_envio_ftp(string cod_entrega, string chave_cte, string xml)
        {
            using (DalSession dalSession = new DalSession())
            {
                UnitOfWork UoW = dalSession.UnitOfWork;

                _Entregas_cte_envio_ftp.InstanciarUnidade(UoW);

                _Entregas_cte_envio_ftp.Update_entregas_cte_envio_ftp(cod_entrega, chave_cte, xml);

            }
        }
        public void  Grava_entregas_cte_envio_ftp(string xml, string id_ws, Entregas_cte_dados_gerados_detalhe objDetalhe)
        {
            using (DalSession dalSession = new DalSession())
            {
                UnitOfWork UoW = dalSession.UnitOfWork;

                _Entregas_cte_envio_ftp.InstanciarUnidade(UoW);

                _Entregas_cte_envio_ftp.Grava_entregas_cte_envio_ftp( xml,  id_ws,  objDetalhe);
               
            }
        }
    }
}
