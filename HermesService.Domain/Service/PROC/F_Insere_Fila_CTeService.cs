using HermesService.Domain.Context;
using HermesService.Domain.Entity;
using HermesService.Domain.Entity.SICLONET.PROC;
using HermesService.Domain.Interfaces.Repositories.Entity.SICLONET.PROC;
using HermesService.Domain.Interfaces.Services.PROC;
using HermesService.Domain.Service.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace HermesService.Domain.Service.PROC
{
    public class F_Insere_Fila_CTeService : BaseService, IF_Insere_Fila_CTeService
    {
        #region Construtor e Interfaces
        private readonly IF_Insere_Fila_CTeRepository _IF_Insere_Fila_CTeRepository;
        public F_Insere_Fila_CTeService(IEntityRepository repo, IF_Insere_Fila_CTeRepository F_Insere_Fila_CTeService) : base(repo)
        {
            _IF_Insere_Fila_CTeRepository = F_Insere_Fila_CTeService;
        }
        #endregion
        public void Insere_Fila_CTe(List<F_Insere_Fila_CTe> pedido)
        {
            using (DalSession dalSession = new DalSession())
            {
                UnitOfWork UoW = dalSession.UnitOfWork;
                try
                {
                    _IF_Insere_Fila_CTeRepository.InstanciarUnidade(UoW);
                    _IF_Insere_Fila_CTeRepository.Insere_Fila_CTe(pedido);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
       
        



    }
}
