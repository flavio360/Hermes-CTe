using HermesService.Domain.Entity.SICLONET;
using System;
using System.Collections.Generic;
using System.Text;

namespace HermesService.Domain.Interfaces.Services
{
    public interface ICte_endereco_web_serviceService
    {
        List<cte_endereco_web_service> ConsultaDadosWSSefaz();
    }
}
