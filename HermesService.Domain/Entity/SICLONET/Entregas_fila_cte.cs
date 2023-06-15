using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HermesService.Domain.Entity.SICLONET
{
    public partial class Entregas_fila_cte : Entregas_cte_filiais_x_remetente
    {
        public int Id_fila { get; set; }
        public string Cod_entrega { get; set; }
        public decimal Vlr_advalorem { get; set; }
        public decimal Aliq_icms { get; set; }
        public decimal Vlr_nfe { get; set; }
        public decimal Vlr_frete { get; set; }
        public decimal Vlr_frete_total { get; set; }
        public decimal Vlr_gris { get; set; }
        public decimal Vlr_icms { get; set; }
        public int Cod_cliente { get; set; }
        public int Cod_empresa { get; set; }
        public int Id_filial_x_remetente { get; set; }
        public decimal Cub_altura { get; set; }
        public decimal Cub_comprimento { get; set; }
        public string Nfe_descricao_produto { get; set; }
        public decimal Cub_largura { get; set; }
        public string Cte_chave_anterior { get; set; }
        public decimal Peso_arquivo { get; set; }
        public decimal Peso_balanca { get; set; }
        public decimal Cub_peso { get; set; }
        public int Quantidade { get; set; }
        public string Nfe_serie { get; set; }
        public string Nfe_numero { get; set; }
        public string Cte_modelo { get; set; }
        public string Cte_chave { get; set; }
        public string Cte_numero { get; set; }
        public string Cte_tipo { get; set; }
        public string Cfop { get; set; }
        public string Cst { get; set; }
        public DateTime Cte_data_transmissao { get; set; }
        public string Cte_modal { get; set; }
        public string Cte_status { get; set; }
        public string Destinatario_endereco { get; set; }
        public string Destinatario_bairro { get; set; }
        public string Destinatario_cep { get; set; }
        public string Destinatario_cidade { get; set; }
        public string Destinatario_cidade_cod_ibge { get; set; }
        public string Destinatario_cpf { get; set; }
        public string Destinatario_uf { get; set; }
        public string Destinatario_nome { get; set; }
        public string Destinatario_complemento { get; set; }
        public string Destinatario_razao_social { get; set; }
        public string Destinatario_telefone { get; set; }
        public string Destinatario_tipo_pessoa { get; set; }
        public string Cte_cancelamento_motivo { get; set; }
        public string Cod_entrega_reprogramada { get; set; }
        public string Nfe_chave { get; set; }
        public string Destinatario_cnpj { get; set; }
        public int Id_detalhe_emitente { get; set; }
        public int Id_detalhe_remetente { get; set; }
        public string Cte_complementar_motivo { get; set; }
    }
}
