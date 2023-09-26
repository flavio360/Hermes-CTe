using HermesService.Domain.Entity.SICLONET;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HermesService.Domain.Interfaces.Services.WS
{
    public interface ITokenRequestService
    {
        string TokenRequestAsync(Autenticacao_info_seguradora objAuenticacao);
    }
}
