using HermesService.Application.EntidadesDTO;
using HermesService.Domain.Entity.SICLONET;
using HermesService.Domain.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HermesService.Domain.Interfaces.Repositories.Entity.SICLONET
{
    public interface IFilaCTeRepository : IRepositoryConnection
    {
        IEnumerable<Entregas> ConsultaPedidosAsync(IEnumerable<Entregas_cte_filiais_x_remetente> clientes);
        IEnumerable<Entregas> ConsultaPedidos(Entregas_cte_filiais_x_remetente clientes);
        void GravaFilaCTe(List<DadosCteDTO> dadosCtes);



    }
}
