using HermesService.Domain.Context;
using HermesService.Domain.Entity;
using HermesService.Domain.Entity.SICLONET;
using HermesService.Domain.Entity.SICLONET.PROC;
using HermesService.Domain.Interfaces.Repositories.Entity.SICLONET.PROC;
using HermesService.Domain.Interfaces.Services.PROC;
using HermesService.Domain.Service.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HermesService.Domain.Service.PROC
{
    public class F_Roteirizador_EntregaService : BaseService, IF_Roteirizador_EntregaService
    {            

        #region Construtor e Interfaces
        private readonly IF_Roteirizador_EntregasRepository _Roteirizador_EntregasService;
        public F_Roteirizador_EntregaService(IEntityRepository repo, IF_Roteirizador_EntregasRepository F_Roteirizador_EntregaService) : base(repo)
        {
            _Roteirizador_EntregasService = F_Roteirizador_EntregaService;
        }
        #endregion
        public enum ProcessoRoteiriza
        {
            SEM_ROTEIRO = 0
        }
        public IEnumerable<Entregas> RoteirizaEntrega(IEnumerable<Entregas> entregas)
        {
 
            foreach (var item in entregas)
                {
                    using (DalSession dalSession = new DalSession())
                    {
                        UnitOfWork UoW = dalSession.UnitOfWork;
                        try
                        {
                            _Roteirizador_EntregasService.InstanciarUnidade(UoW);
                            var ret = _Roteirizador_EntregasService.RoteirizaEntrega(item.Codentregacli, item.Cep_Dest, item.Cod_cliente.ToString(), item.Codproduto.ToString(), item.Estado, item.Codusuario.ToString(), item.Codbase, null); 

                            if (ret.D_base == "SEM ROTEIRO")
                            {
                                item.Problema = ProcessoRoteiriza.SEM_ROTEIRO.ToString();                            
                            }                            
                        }
                        catch (Exception ex )
                        {
                            throw ex;
                        }
                    }
                }  
            return entregas;
        }
    }
}
