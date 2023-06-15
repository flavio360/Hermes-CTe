using HermesService.Domain.Entity.SICLONET;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HermesService.Domain.Interfaces.Services
{
    public interface IObeterPedidosService
    {
        IEnumerable<Entregas> ObeterPedidos(IEnumerable<Entregas_cte_filiais_x_remetente> clientes);
    }
}
