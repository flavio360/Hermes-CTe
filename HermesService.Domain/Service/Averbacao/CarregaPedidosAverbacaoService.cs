using HermesService.Domain.Entity;
using HermesService.Domain.Entity.SICLONET;
using HermesService.Domain.Interfaces.Repositories;
using HermesService.Domain.Interfaces.Services;
using HermesService.Domain.Service.Base;
using System;
using System.Collections.Generic;
using System.Text;
using HermesService.Domain.Service;
using HermesService.Domain.Context;

namespace HermesService.Domain.Service
{
    public class CarregaPedidosAverbacaoService : BaseService, ICarregaPedidosAverbacaoService
    {

        private readonly IEntregas_cte_envio_ftpRepository _Entregas_cte_envio_ftpRepository;
        public CarregaPedidosAverbacaoService(IEntityRepository repo, IEntregas_cte_envio_ftpRepository Entregas_cte_envio_ftpRepository) : base(repo)
        {
            _Entregas_cte_envio_ftpRepository = Entregas_cte_envio_ftpRepository;
        }

        List<Entregas_cte_envio_ftp> ICarregaPedidosAverbacaoService.SelectAverbados()
        {
            using (DalSession dalSession = new DalSession())
            {
                UnitOfWork UoW = dalSession.UnitOfWork;
                try
                {
                    _Entregas_cte_envio_ftpRepository.InstanciarUnidade(UoW);
                    var ret = _Entregas_cte_envio_ftpRepository.SelectPedidosAverbacao();
                    return ret;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        string ICarregaPedidosAverbacaoService.DeleteAverbados()
        {
            throw new NotImplementedException();
        }

        string ICarregaPedidosAverbacaoService.UpdateAverbados()
        {
            throw new NotImplementedException();
        }

        string ICarregaPedidosAverbacaoService.InsertAverbados()
        {
            throw new NotImplementedException();
        }
    }
}
