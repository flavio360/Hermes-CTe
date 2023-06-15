using HermesService.Domain.Context;
using HermesService.Domain.Entity;
using HermesService.Domain.Entity.SICLONET;
using HermesService.Domain.Interfaces.Repositories.Entity.SICLONET;
using HermesService.Domain.Interfaces.Services;
using HermesService.Domain.Service.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace HermesService.Domain.Service
{
    public class Entregas_fila_cteService : BaseService, IEntregas_fila_cteService
    {
        private readonly IEntregas_fila_cteRepository _Entregas_fila_cte;

        public Entregas_fila_cteService(IEntityRepository repo, IEntregas_fila_cteRepository Entregas_fila_cteCteService) : base(repo)
        {
            _Entregas_fila_cte = Entregas_fila_cteCteService;
        }

        public void DeleteEntregas_Fila_Ctes()
        {
            throw new NotImplementedException();
        }

        public void InsertEntregas_Fila_Ctes()
        {
            throw new NotImplementedException();
        }

        public List<Entregas_fila_cte> SelectEntregas_Fila_Ctes()
        {
            throw new NotImplementedException();
        }

        public void UpdateEntregas_Fila_Ctes(Entregas_cte_dados_gerados_detalhe objEntrega)
        {
            using (DalSession dalSession = new DalSession())
            {
                UnitOfWork UoW = dalSession.UnitOfWork;
                try
                {
                    _Entregas_fila_cte.InstanciarUnidade(UoW);
                    _Entregas_fila_cte.UpdateEntregas_Fila_Ctes(objEntrega);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
