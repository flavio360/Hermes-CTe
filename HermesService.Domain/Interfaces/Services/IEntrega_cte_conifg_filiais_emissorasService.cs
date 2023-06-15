using HermesService.Domain.Entity.SICLONET;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HermesService.Domain.Interfaces.Services
{
    public interface IEntrega_cte_conifg_filiais_emissorasService 
    {
        Task<Entrega_cte_conifg_filiais_emissoras> ObterEmpresasEmissorarHabilitadas(string cod_empresa);
    }
}
