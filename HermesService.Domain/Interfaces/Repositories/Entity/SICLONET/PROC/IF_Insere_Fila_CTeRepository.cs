using HermesService.Domain.Entity.SICLONET.PROC;
using HermesService.Domain.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace HermesService.Domain.Interfaces.Repositories.Entity.SICLONET.PROC
{
    public interface IF_Insere_Fila_CTeRepository : IRepositoryConnection
    {
        void Insere_Fila_CTe(List<F_Insere_Fila_CTe> pedido);
    }
}
