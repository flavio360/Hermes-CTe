using HermesService.Domain.Entity.SICLONET;
using HermesService.Domain.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HermesService.Domain.Interfaces.Repositories.Entity.SICLONET
{
    public interface IProcessaRemessaParaFilaCTeRepository : IRepositoryConnection
    {
        IEnumerable<Entregas_cte_filiais_x_remetente> ObterClientesHabilitadosCTe();

        string ObeterUltimoCTeNumeroCliente(string Codcliente);

    }
}
