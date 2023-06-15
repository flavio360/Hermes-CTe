using HermesService.Domain.Context;
using HermesService.Domain.Entity;
using HermesService.Domain.Entity.SICLONET;
using HermesService.Domain.Interfaces.Repositories.Entity.SICLONET;
using HermesService.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HermesService.Domain.Service.Base
{
    public class ObterPedidosService : BaseService, IObeterPedidosService
    {

        #region Construtor e Interfaces
        private readonly IFilaCTeRepository _FilaCTeRepository;

        public ObterPedidosService(IEntityRepository repo, IFilaCTeRepository FilaCTeRepository) : base(repo)
        {
            _FilaCTeRepository = FilaCTeRepository;
        }

        #endregion

        public IEnumerable<Entregas> ObeterPedidos(IEnumerable<Entregas_cte_filiais_x_remetente> clientes)
        {
            using (DalSession dalSession = new DalSession())
            {
                UnitOfWork UoW = dalSession.UnitOfWork;               

                _FilaCTeRepository.InstanciarUnidade(UoW);
                var objPedido = _FilaCTeRepository.ConsultaPedidosAsync(clientes);                   

                return objPedido;


            }

        }
    }
}
