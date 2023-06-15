using HermesService.Domain.Entity.SICLONET.PROC;
using HermesService.Domain.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace HermesService.Domain.Interfaces.Repositories.Entity.SICLONET.PROC
{
    public interface IF_Roteirizador_EntregasRepository:IRepositoryConnection
    {
        F_roteirizador_entregas RoteirizaEntrega(string codEntregaCli, string cep, string codCliente, string codproduto, string estado, string codusuario, string codbase, string codservico = null);
    }
}
