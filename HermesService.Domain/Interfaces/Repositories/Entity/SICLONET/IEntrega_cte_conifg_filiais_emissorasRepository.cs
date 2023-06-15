using HermesService.Domain.Entity.SICLONET;
using HermesService.Domain.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HermesService.Domain.Interfaces.Repositories.Entity.SICLONET
{
    public interface IEntrega_cte_conifg_filiais_emissorasRepository : IRepositoryConnection
    {
        Entrega_cte_conifg_filiais_emissoras ConsultaEmissoraAtiva(string cod_empresa);
    }
}
