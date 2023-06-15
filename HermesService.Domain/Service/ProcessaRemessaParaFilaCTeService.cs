using HermesService.Application.EntidadesDTO;
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
    public class ProcessaRemessaParaFilaCTeService : BaseService, IProcessaRemessaParaFilaCTeService
    {

        #region interfaces e Construtores
        private readonly IProcessaRemessaParaFilaCTeRepository _ProcessaRemessaParaFilaCTeRepository;

        public ProcessaRemessaParaFilaCTeService(IEntityRepository repo, IProcessaRemessaParaFilaCTeRepository ProcessaRemessaParaFilaCTeRepository) : base(repo)
        {
            _ProcessaRemessaParaFilaCTeRepository = ProcessaRemessaParaFilaCTeRepository;
        }
        #endregion
        public IEnumerable<Entregas_cte_filiais_x_remetente> ConultaClientesEmissoresCTeService()
        {
            using (DalSession dalSession = new DalSession())
            {
                UnitOfWork UoW = dalSession.UnitOfWork;
                try
                {                    
                    _ProcessaRemessaParaFilaCTeRepository.InstanciarUnidade(UoW);
                    var ListaClientesCTe = _ProcessaRemessaParaFilaCTeRepository.ObterClientesHabilitadosCTe();                    

                    return ListaClientesCTe;
                }
                catch (Exception)
                {
                    throw;
                }  
            }
        }

        public void GravaFilaCTeService(List<DadosCteDTO> entregas_Fila_Ctes)
        {
            throw new NotImplementedException();
        }

        public Entregas ObeterPedidosService(Entregas_cte_filiais_x_remetente cliente)
        {
            throw new NotImplementedException();
        }

        public string ObeterUltimoCTeNumeroClienteService(string Codcliente)
        {
            using (DalSession dalSession = new DalSession())
            {
                UnitOfWork UoW = dalSession.UnitOfWork;
                try
                {
                    _ProcessaRemessaParaFilaCTeRepository.InstanciarUnidade(UoW);
                    string ret = _ProcessaRemessaParaFilaCTeRepository.ObeterUltimoCTeNumeroCliente(Codcliente);
                    return ret;
                }
                catch (Exception ex)
                {
                    throw ex;
                }       
            }   
        }
    }
}
