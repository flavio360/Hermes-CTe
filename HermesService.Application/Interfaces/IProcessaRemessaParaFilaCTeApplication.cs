using HermesService.Domain.Entity.SICLONET;
using System;
using System.Collections.Generic;
using System.Text;

namespace HermesService.Application.Interfaces
{
    public interface IProcessaRemessaParaFilaCTeApplication
    {
        void ObterClientesEmissoresApplication(string tpEmissao = "0");
    }
}
