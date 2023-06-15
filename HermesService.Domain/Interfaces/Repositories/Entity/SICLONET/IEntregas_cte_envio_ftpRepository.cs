using HermesService.Domain.Entity.SICLONET;
using HermesService.Domain.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace HermesService.Domain.Interfaces.Services
{
    public interface IEntregas_cte_envio_ftpRepository : IRepositoryConnection 
    {
        void Grava_entregas_cte_envio_ftp(string xml, string id_ws, Entregas_cte_dados_gerados_detalhe objDetalhe);

        string Consulta_entregas_cte_envio_ftp(string cod_entrega, string numero_cte);

        void Update_entregas_cte_envio_ftp(string cod_entrega, string numero_cte,string xml);
    }
}
