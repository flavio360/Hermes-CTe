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
    public class Autenticacao_info_seguradoraService : BaseService, IAutenticacao_info_seguradoraService
    {
        
        #region interfaces e Construtores
        private readonly IAutenticacao_info_seguradoraRepository _Autenticacao_info_seguradora;
        public Autenticacao_info_seguradoraService(IEntityRepository repo, IAutenticacao_info_seguradoraRepository Autenticacao_info_seguradora) : base(repo)
        {
            _Autenticacao_info_seguradora = Autenticacao_info_seguradora;
        }
        #endregion
        public Autenticacao_info_seguradora SelectAutenticacao_info_seguradora(string funcao)
        {            
            using (DalSession dalSession = new DalSession())
            {
                UnitOfWork UoW = dalSession.UnitOfWork;

                _Autenticacao_info_seguradora.InstanciarUnidade(UoW);
               
                var objAutenticacao = _Autenticacao_info_seguradora.SelectInfoSeguradora(funcao);

                return objAutenticacao;
            }
        }
    }
}
