using HermesService.Domain.Entity.SICLONET;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HermesService.Domain.Interfaces.Services
{
    public interface IProcessaCTeGeraSEFAZService
    {
        List<Entregas_cte_dados_gerados_detalhe> DadosProcessoGeraCTe(string cod_empresa);
    }
}
