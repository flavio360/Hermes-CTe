using HermesService.Domain.Entity.SICLONET;
using System;
using System.Collections.Generic;
using System.Text;

namespace HermesService.Domain.Interfaces.Repositories.Entity.SICLONET
{
    public interface IEntregas_cte_erroRepository
    {
        void GravaRejeicaoSefaz(Entregas_cte_erro objErro);

    }
}
