using HermesService.Domain.Entity.SICLONET;
using System;
using System.Collections.Generic;
using System.Text;

namespace HermesService.Domain.Interfaces.Repositories
{
    public interface IEntregas_cte_envio_ftpService
    {
        void Grava_entregas_cte_envio_ftp(string xml, string id_ws, Entregas_cte_dados_gerados_detalhe objDetalhe);
        string Consulta_entregas_cte_envio_ftp(string cod_entrega, string chave_cte);
        void Update_entregas_cte_envio_ftp(string cod_entrega, string chave_cte, string xml);
    }
}
