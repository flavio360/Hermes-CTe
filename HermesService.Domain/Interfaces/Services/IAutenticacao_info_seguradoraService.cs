using HermesService.Domain.Entity.SICLONET;
using System;
using System.Collections.Generic;
using System.Text;

namespace HermesService.Domain.Interfaces.Services
{
    public interface IAutenticacao_info_seguradoraService
    {
        Autenticacao_info_seguradora SelectAutenticacao_info_seguradora(string funcao);
    }
}
