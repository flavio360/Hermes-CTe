using System;
using System.Collections.Generic;
using System.Text;

namespace HermesService.Application.EntidadesDTO
{
    public class DadosCteDTO : ErroCTeDTO
    {
        
        public string CodEntrega { get; set; }
        public decimal VlrAdvalorem { get; set; }
        public decimal AliqIcms { get; set; }
        public decimal VlrNfe { get; set; }
        public decimal VlrFrete { get; set; }
        public decimal VlrFreteTotal { get; set; }
        public decimal VlrGris { get; set; }
        public decimal VlrIcms { get; set; }
        public int CodCliente { get; set; }
        public int CodProduto { get; set; }
        public int CodEmpresa { get; set; }
        public string IdFilial_x_Remetente { get; set; }
        public decimal CubAltura { get; set; }
        public decimal CubComprimento { get; set; }
        public string NfeDescricaoProduto { get; set; }
        public decimal CubLargura { get; set; }
        public string CteChaveAnterior { get; set; }
        public decimal PesoArquivo { get; set; }
        public decimal PesoBalanca { get; set; }
        public decimal CubPeso { get; set; }
        public int Quantidade { get; set; }
        public string NfeSerie { get; set; }
        public string NfeNumero { get; set; }
        public string CteModelo { get; set; }
        public string CteChave { get; set; }
        public string CteNumero { get; set; }
        public string CteTipo { get; set; }
        public string Cfop { get; set; }
        public string Cst { get; set; }
        public string CteDataTransmissao { get; set; }
        public string CteModal { get; set; }
        public string CteStatus { get; set; }
        public string DestinatarioEndereco { get; set; }
        public string DestinatarioBairro { get; set; }
        public string DestinatarioCep { get; set; }
        public string DestinatarioCidade { get; set; }
        public string DestinatarioCidadeCodIbge { get; set; }
        public string DestinatarioCpf { get; set; }
        public string DestinatarioNome { get; set; }
        public string DestinatarioComplemento { get; set; }
        public string DestinatarioRazaoSocial { get; set; }
        public string DestinatarioTelefone { get; set; }
        public string DestinatarioEstado { get; set; }
        public string DestinatarioTipoPessoa { get; set; }
        public string CteCancelamentoMotivo { get; set; }
        public string CodEntregaReprogramada { get; set; }
        public string NfeChave { get; set; }
        public string DestinatarioCnpj { get; set; }
        public string CteComplementarMotivo { get; set; }
        public string Observacao { get; set; }
        public string DestinatarioTipo_pessoa { get; set; }
        public string EmitenteCnpj { get; set; }
        public string EmitenteCidadecodIbge { get; set; }
        public string EmitenteNome { get; set; }
        public string EmitenteComplemento { get; set; }
        public string EmitenteFantasia { get; set; }
        public string EmitenteRazaosocial { get; set; }
        public string EmitenteUf { get; set; }
        public string EmitenteTelefone { get; set; }
        public string Rntrc { get; set; }
        public string RemetenteCnpj { get; set; }
        public string RemetenteCidade_cod_ibge { get; set; }
        public string RemetenteCpf_cnpj { get; set; }
        public string RemetenteNome { get; set; }
        public string RemetenteComplemento { get; set; }
        public string RemetenteFantasia { get; set; }
        public string RemetenteRazaosocial { get; set; }
        public string RemetenteTelefone { get; set; }
        public string RemetenteUf { get; set; }
        public string IdDetalheEmitente { get; set; }
        public string IdDetalheRemetente { get; set; }

        public List<DadosCteDTO> DadosCtes { get; set; }
    }
}
