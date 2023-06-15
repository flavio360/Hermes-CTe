using HermesService.Domain.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace HermesService.Domain.Interfaces.Services
{
    public interface IEntregas_codigos_cidades_ibgeService 
    {
        string ObeterCodigoIBGE(string cidade, string uf);
    }
}
