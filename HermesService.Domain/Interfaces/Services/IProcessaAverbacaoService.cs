using HermesService.Domain.Entity.SICLONET;
using System;
using System.Collections.Generic;
using System.Text;

namespace HermesService.Domain.Interfaces.Services
{
    public interface IProcessaAverbacaoService
    {
        Entregas_cte_envio_ftp ProcessaPedidosAverbacao();
    }
}
