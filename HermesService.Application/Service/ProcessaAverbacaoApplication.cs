using HermesService.Application.Interfaces;
using HermesService.Domain.Entity.SICLONET;
using HermesService.Domain.Interfaces.Services;
using HermesService.Domain.Interfaces.Services.WS;
using HermesService.Domain.Utilities;
using System;
using System.Collections.Generic;

namespace HermesService.Application.Service
{
    public class ProcessaAverbacaoApplication : IProcessaAverbacaoApplication
    {

        #region interfaces e Construtores

        private readonly IProcessaAverbacaoService _ProcessaAverbacaoService;
        private readonly ICarregaPedidosAverbacaoService _CarregaPedidosAverbacaoService;
        private readonly IAutenticacao_info_seguradoraService _Autenticacao_info_seguradoraService;
        private readonly ITokenRequestService _TokenRequestService;
        private readonly IEnviaCTeAverbacaoService _EnviaCTeAverbacao;
        Autenticacao_info_seguradora objAutenticacao;

       public ProcessaAverbacaoApplication
        (
             IProcessaAverbacaoService ProcessaAverbacaoService,
             ICarregaPedidosAverbacaoService CarregaPedidosAverbacaoService,
             IAutenticacao_info_seguradoraService Autenticacao_info_seguradoraService,
             ITokenRequestService TokenRequestService,
             IEnviaCTeAverbacaoService EnviaCTeAverbacao

        )
        {
            _ProcessaAverbacaoService = ProcessaAverbacaoService;
            _CarregaPedidosAverbacaoService = CarregaPedidosAverbacaoService;
            _Autenticacao_info_seguradoraService = Autenticacao_info_seguradoraService;
            _TokenRequestService = TokenRequestService;
            _EnviaCTeAverbacao = EnviaCTeAverbacao;

        }
        #endregion


        void IProcessaAverbacaoApplication.ProcessaAverbacaoApplication()
        {
            string token = string.Empty;
            string codEnrega = string.Empty;
            string codCliente = string.Empty;
            var objAverba =_CarregaPedidosAverbacaoService.SelectAverbados();
            DateTime endTime;
            DateTime startTime;
            if (objAverba.Count != 0)
            {
                //implementar o serviço que busca o token
                objAutenticacao = _Autenticacao_info_seguradoraService.SelectAutenticacao_info_seguradora(AverbacaoEnums.funcao.AUTH.ToString());

                var objWS = _Autenticacao_info_seguradoraService.SelectAutenticacao_info_seguradora(AverbacaoEnums.funcao.CTE.ToString());
                var URLWS = objWS.Ws_Endereco;
                startTime = DateTime.Now; // Grava a hora atual
                endTime = startTime.AddMinutes(50);
                token = _TokenRequestService.TokenRequestAsync(objAutenticacao);

                foreach (var item in objAverba)
                {
                    codEnrega = item.sCod_entrega;
                    codCliente = item.sCod_cliente;

                    if (DateTime.Now >= endTime)
                    {
                        startTime = DateTime.Now;
                        endTime = startTime.AddMinutes(50);
                        token = _TokenRequestService.TokenRequestAsync(objAutenticacao);
                    }

                    var ret = _EnviaCTeAverbacao.RequestAverbacao(token, item.sCte_xml, URLWS, codCliente, codEnrega, objAutenticacao);
                }
            }
        } 
    }
}
