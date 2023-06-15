using HermesService.Application.Interfaces;
using HermesService.Domain.Entity.SICLONET;
using HermesService.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using HermesService.Application.AutoMapper;
using HermesService.Application.EntidadesDTO;
using static HermesService.Application.AutoMapper.MapperFactory;
using HermesService.Application.Utilities.CTe;
using HermesService.Domain.Interfaces.Repositories.Entity.SICLONET;
using HermesService.Domain.Interfaces.Services.PROC;
using Hermes.BLL.Ferramentas;
using HermesService.Domain.Entity.SICLONET.PROC;
using HermesService.Domain.Utilities;
using System.Linq;

namespace HermesService.Application.Service
{
    public class ProcessaRemessaParaFilaCTeApplication : IProcessaRemessaParaFilaCTeApplication
    {
        string dataLog = string.Empty;
        string codcliente = string.Empty;
        string nCTe = string.Empty;
        CFOP cfop = new CFOP();

        #region interfaces e Construtores
        private readonly IProcessaRemessaParaFilaCTeService _ProcessaRemessaParaFilaCTeService;
        private readonly IObeterPedidosService _ObeterPedidosService;
        private readonly IFilaErroCteService _FilaErroCteService;
        private readonly IF_Roteirizador_EntregaService _F_Roteirizador_EntregaService;
        private readonly IF_Insere_Fila_CTeService _IF_Insere_Fila_CTeService;
        private readonly IEntregas_codigos_cidades_ibgeService _IEntregas_codigos_cidades_ibgeService;
        private readonly IF_Calcula_Frete_Tributos_EcommerceService _F_Calcula_Frete_Tributos_EcommerceService;

        public ProcessaRemessaParaFilaCTeApplication
        (
             IProcessaRemessaParaFilaCTeService ProcessaRemessaParaFilaCTeService,
             IObeterPedidosService ObeterPedidosService,
             IFilaErroCteService FilaErroCteService,
             IF_Roteirizador_EntregaService F_Roteirizador_EntregaService,
             IF_Insere_Fila_CTeService F_Insere_Fila_CTeService,
             IEntregas_codigos_cidades_ibgeService Entregas_codigos_cidades_ibgeService,
             IF_Calcula_Frete_Tributos_EcommerceService F_Calcula_Frete_Tributos_EcommerceService
        )
        {
            _ProcessaRemessaParaFilaCTeService = ProcessaRemessaParaFilaCTeService;
            _ObeterPedidosService = ObeterPedidosService;
            _FilaErroCteService = FilaErroCteService;
            _F_Roteirizador_EntregaService = F_Roteirizador_EntregaService;
            _IF_Insere_Fila_CTeService = F_Insere_Fila_CTeService;
            _IEntregas_codigos_cidades_ibgeService = Entregas_codigos_cidades_ibgeService;
            _F_Calcula_Frete_Tributos_EcommerceService = F_Calcula_Frete_Tributos_EcommerceService;
        }       
        #endregion

        public void ObterClientesEmissoresApplication(string tpEmissao="0")
        {
            try
            {               
               var objClienteEmissor = _ProcessaRemessaParaFilaCTeService.ConultaClientesEmissoresCTeService();
               var objPedidos = _ObeterPedidosService.ObeterPedidos(objClienteEmissor);
                
                if (objPedidos.Count() != 0)
               {   
                    #region valida o que esta na abrangencia ou é correios.  
                    objPedidos = _F_Roteirizador_EntregaService.RoteirizaEntrega(objPedidos);  
                    #endregion

                    MapperFactory.CarregaMapper(Processo.FILACTE);

                    var encomendas = MapperFactory.Mapper?.Map<IEnumerable<Entregas>, List<F_Insere_Fila_CTe>>(objPedidos);

                    dataLog = DateTime.Now.ToString(); 

                    foreach (var item in encomendas)
                    {
                        string ste = "\n cod_entrega: " + item.Cod_entrega;
                        dataLog = dataLog + ste;

                        if (item.Erro == true)
                        {
                            _FilaErroCteService.GravaErroCte(item.Cod_entrega, item.DescricaoErro);
                        }                        
                    }

                    encomendas.RemoveAll(x => x.Erro == true);

                    List<F_Insere_Fila_CTe> listaOrdenada = new List<F_Insere_Fila_CTe>();
                    
                    //gera numero CTe
                    var numeroGerado = new List<ReservaNumeroCTe>();
                    
                    foreach (var tratado in encomendas.OrderBy(x => x.Cod_cliente))
                    {
                        if (codcliente == string.Empty)
                        {
                            codcliente = tratado.Cod_cliente.ToString();
                        }

                        if (nCTe == string.Empty || codcliente != tratado.Cod_cliente.ToString())
                        {
                            nCTe = _ProcessaRemessaParaFilaCTeService.ObeterUltimoCTeNumeroClienteService(tratado.Cod_cliente.ToString());
                            codcliente = tratado.Cod_cliente.ToString();

                            if (nCTe == null || nCTe == string.Empty)
                            {
                                nCTe = "1000";                                
                            }
                            else
                            {
                                nCTe = (Convert.ToInt32(nCTe) + 1).ToString();
                            }

                        }
                        else
                        {
                            nCTe = (Convert.ToInt32(nCTe) + 1).ToString();
                        }

                        tratado.Cte_numero = nCTe;
                    }


                    //Gera chave CTe e Define CodCidadeIBGE 
                    foreach (var item in encomendas)
                    {
                        var cteTools = new CTeTools();

                        var nChaveCTe = cteTools.GerarNumeroCTe(item.Emitente_uf, item.Emitente_cnpj,  tpEmissao, item.Cod_cliente.ToString(), item.Cte_numero, item.Cod_entrega);

                        item.Cte_tipo = tpEmissao; //valor passado por paramentro para 
                        item.Cte_chave = nChaveCTe;
                        item.destinatario_cidade_cod_ibge = _IEntregas_codigos_cidades_ibgeService.ObeterCodigoIBGE(item.destinatario_cidade,item.Destinatario_uf);

                        if (item.destinatario_cidade_cod_ibge == null)
                        {
                            item.DescricaoErro = CTEEnums.INCOSISTENCIA_DADOS.CODIGO_IBGE_NULL.ToString();
                            _FilaErroCteService.GravaErroCte(item.Cod_entrega, item.DescricaoErro);
                            item.Erro = true;
                        }
                        item.Cte_modal = "57"; //rodoviário

                        item.Cfop = cfop.DefinirCFOP(item.Remetente_uf, item.Destinatario_uf);
                        item.Cfop = "6108";




                    }

                    encomendas.RemoveAll(x => x.Erro == true);
                    //##############calculos de frete e icms######################

                    foreach (var calcEntrega in encomendas)
                    {
                        var ret = _F_Calcula_Frete_Tributos_EcommerceService.CalculaExpressaService(calcEntrega.Cod_entrega_cliente, calcEntrega.Remetente_uf, calcEntrega.Destinatario_uf, calcEntrega.destinatario_cidade_cod_ibge, calcEntrega.Remetente_cidade_cod_ibge);

                        if (calcEntrega.Erro == false)
                        {
                            var calc = new CalculaImpostos();

                            var retImpostos = calc.CalculaImpostosCTe(ret);

                            calcEntrega.Vlr_frete = Convert.ToDecimal( ret.Valor_frete.ToString("F"));
                            calcEntrega.Aliq_icms = Convert.ToDecimal(ret.Taxa_icms.ToString("F"));

                            calcEntrega.Vlr_icms = retImpostos.Vlr_icms;

                            calcEntrega.Vlr_advalorem = Convert.ToDecimal(ret.Taxa_advalorem.ToString("F"));
                            calcEntrega.Vlr_gris = Convert.ToDecimal(ret.Valor_gris.ToString("F"));

                            calcEntrega.Cte_status = ((int)CTEEnums.STATUS_CTE_IL.PendenteEnvio).ToString();
                        }
                        else
                        {
                            calcEntrega.Observacao = "PROCESSAMENTO_CALCULO_( " + ret.Msg + " )" ;
                            calcEntrega.Erro = true;
                        }
                    }

                    encomendas.RemoveAll(x => x.Erro == true);

                    //começa a tratar propriedades para popular tabela de erro'
                    var validar = new ValidaDadosFiscaisApp();
                    var dadosTratados = validar.ValidarCamposFiscais(encomendas);
                    //Popula tabelas de erro

                    
                    if (dadosTratados.ToList().Any(e => e.Erro == true))
                    {
                        foreach (var itemErro in dadosTratados)
                        {
                            if (itemErro.Erro == true)
                            {
                                //POPULA TABELA ERRO
                                MapperFactory.CarregaMapper(Processo.ERROCTE);

                                var encomendaErro = MapperFactory.Mapper?.Map<List<F_Insere_Fila_CTe>, List<Entregas_cte_erro>>(dadosTratados);

                                _FilaErroCteService.GravaFilaErroCte(encomendaErro);
                            }
                        } 
                    }

                    dadosTratados.RemoveAll(x => x.Erro == true);
                    
                    //Popula tabelas da Fila CTe

                    if (dadosTratados.Count > 0)
                    {
                        
                        _IF_Insere_Fila_CTeService.Insere_Fila_CTe(dadosTratados); 
                    }

                    dataLog = dataLog + "\n" + DateTime.Now.ToString();
                    WriteFile.WriteWSCTeLog("Queue", dataLog);
                }
            }
            catch (Exception ex)
            {
                WriteFile.WriteWSCTeLog(ex.Message, ex.Message.ToString());                
            }
        }
    }
}
