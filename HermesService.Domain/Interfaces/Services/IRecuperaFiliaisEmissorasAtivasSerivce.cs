using HermesService.Domain.Entity.SICLONET;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HermesService.Domain.Interfaces.Services
{
    public interface IRecuperaFiliaisEmissorasAtivasSerivce
    {
        Entrega_cte_conifg_filiais_emissoras RecuperaFiliaisEmissorasAtivas(string cod_empresa);
    }
}
