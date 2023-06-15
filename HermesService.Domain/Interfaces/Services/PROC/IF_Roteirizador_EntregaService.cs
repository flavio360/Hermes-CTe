using HermesService.Domain.Entity.SICLONET;
using HermesService.Domain.Entity.SICLONET.PROC;
using System;
using System.Collections.Generic;
using System.Text;

namespace HermesService.Domain.Interfaces.Services.PROC
{
    public interface IF_Roteirizador_EntregaService
    {

        IEnumerable<Entregas> RoteirizaEntrega(IEnumerable<Entregas> entregas);
    }
}
