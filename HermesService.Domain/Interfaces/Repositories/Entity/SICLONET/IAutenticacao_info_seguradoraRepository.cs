using HermesService.Domain.Entity.SICLONET;
using HermesService.Domain.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace HermesService.Domain.Interfaces.Repositories.Entity.SICLONET
{
    public interface IAutenticacao_info_seguradoraRepository : IRepositoryConnection
    {
        Autenticacao_info_seguradora SelectInfoSeguradora(string funcao);
        string UpdateInfoSeguradora();
        string DeleteInfoSeguradora();
        string InsertInfoSeguradora();
    }
}
