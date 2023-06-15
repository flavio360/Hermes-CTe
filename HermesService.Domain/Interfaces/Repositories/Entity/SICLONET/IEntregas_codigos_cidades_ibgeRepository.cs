using HermesService.Domain.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace HermesService.Domain.Interfaces.Repositories.Entity.SICLONET
{
    public interface IEntregas_codigos_cidades_ibgeRepository : IRepositoryConnection
    {
        string ObeterCodigoIBGE(string cidade, string uf);
    }
}
