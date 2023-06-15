using HermesService.Application.EntidadesDTO;
using HermesService.Domain.Entity.SICLONET;
using HermesService.Domain.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace HermesService.Domain.Interfaces.Services
{
    public interface IProcessaRemessaParaFilaCTeService 
    {
        IEnumerable<Entregas_cte_filiais_x_remetente> ConultaClientesEmissoresCTeService();

        Entregas ObeterPedidosService(Entregas_cte_filiais_x_remetente cliente);

        string ObeterUltimoCTeNumeroClienteService(string Codcliente);

        void GravaFilaCTeService(List<DadosCteDTO> entregas_Fila_Ctes);
    }
}
