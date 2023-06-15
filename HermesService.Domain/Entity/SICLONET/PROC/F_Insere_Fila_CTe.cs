using HermesService.Application.EntidadesDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HermesService.Domain.Entity.SICLONET.PROC
{
    public class F_Insere_Fila_CTe : ErroCTeDTO
    {
        [Required]
        [StringLength(30)]
        public string Cod_entrega { get; set; }

        public string Id_fila { get; set; }
        public string Cod_entrega_cliente { get; set; }
        public decimal Vlr_advalorem { get; set; }
        public decimal Aliq_icms { get; set; }
        public decimal Vlr_nfe { get; set; }
        public decimal Vlr_frete_total { get; set; }
        public decimal Vlr_frete { get; set; }
        public decimal Vlr_gris { get; set; }
        public decimal Vlr_icms { get; set; }
        public int Cod_cliente { get; set; }
        public string Cod_empresa { get; set; }
        public int Id_filial_x_remetente { get; set; }
        public decimal Cub_altura { get; set; }
        public decimal Cub_comprimento { get; set; }
        public string Nfe_descricao_produto { get; set; }
        public decimal Cub_largura { get; set; }
        [Required]
        [StringLength(44)]
        public string Cte_chave_anterior { get; set; }
        public decimal Peso_arquivo { get; set; }
        public decimal Peso_balanca { get; set; }
        public decimal Cub_peso { get; set; }
        public string Quantidade { get; set; }
        [Required]
        [StringLength(3)]
        public string Nfe_serie { get; set; }

        [Required]
        [StringLength(9)]
        public string Nfe_numero { get; set; }

        [Required]
        [StringLength(3)]
        public string Cte_modelo { get; set; }

        [Required]
        [StringLength(44)]
        public string Cte_chave { get; set; }

        [Required]
        [StringLength(9)]
        public string Cte_numero { get; set; }

        [Required]
        [StringLength(2)]
        public string Cte_tipo { get; set; }

        [Required]
        [StringLength(4)]
        public string Cfop { get; set; }

        [Required]
        [StringLength(2)]
        public string Cst { get; set; }
        public string Cte_data_insert_fila { get; set; }

        [Required]
        [StringLength(2)]
        public string Cte_modal { get; set; }

        [Required]
        [StringLength(4)]
        public string Cte_status { get; set; }

        [Required]
        [StringLength(100)]
        public string Destinatario_endereco { get; set; }

        [Required]
        [StringLength(40)]
        public string Destinatario_bairro { get; set; }

        [Required]
        [StringLength(8)]
        public string Destinatario_cep { get; set; }

        [Required]
        [StringLength(10)]
        public string destinatario_cidade { get; set; }

        [Required]
        [StringLength(7)]
        public string destinatario_cidade_cod_ibge { get; set; }

        [Required]
        [StringLength(11)]
        public string destinatario_cpf { get; set; }

        [Required]
        [StringLength(75)]
        public string destinatario_nome { get; set; }

        [Required]
        [StringLength(20)]
        public string destinatario_complemento { get; set; }

        [Required]
        [StringLength(75)]
        public string destinatario_razao_social { get; set; }

        [Required]
        [StringLength(15)]
        public string destinatario_telefone { get; set; }

        [Required]
        [StringLength(1)]
        public string Destinatario_tipo_pessoa { get; set; }

        [Required]
        [StringLength(300)]
        public string Cte_complementar_motivo { get; set; }

        [Required]
        [StringLength(30)]
        public string Cod_entrega_reprogramada { get; set; }

        [Required]
        [StringLength(44)]
        public string Nfe_chave { get; set; }

        [Required]
        [StringLength(14)]
        public string Destinatario_cnpj { get; set; }

        [Required]
        [StringLength(300)]
        public string Cte_cancelamento_motivo { get; set; }

        [Required]
        [StringLength(2)]
        public string Destinatario_uf { get; set; }

        [Required]
        [StringLength(14)]
        public string Emitente_cnpj { get; set; }

        [Required]
        [StringLength(7)]
        public string Emitente_cidade_cod_ibge { get; set; }

        [Required]
        [StringLength(75)]
        public string Emitente_nome { get; set; }

        [Required]
        [StringLength(20)]
        public string Emitente_complemento { get; set; }

        [Required]
        [StringLength(75)]
        public string Emitente_fantasia { get; set; }

        [Required]
        [StringLength(75)]
        public string Emitente_razaosocial { get; set; }

        [Required]
        [StringLength(2)]
        public string Emitente_uf { get; set; }

        [Required]
        [StringLength(15)]
        public string Emitente_telefone { get; set; }

        [Required]
        [StringLength(9)]
        public string Rntrc { get; set; }

        [Required]
        [StringLength(8)]
        public string Emitente_cep { get; set; }

        [Required]
        [StringLength(14)]
        public string Remetente_cnpj { get; set; }

        [Required]
        [StringLength(10)]
        public string Remetente_cidade_cod_ibge { get; set; }

        [Required]
        [StringLength(14)]
        public string Remetente_cpf_cnpj { get; set; }

        [Required]
        [StringLength(75)]
        public string Remetente_nome { get; set; }

        [Required]
        [StringLength(20)]
        public string Remetente_complemento { get; set; }

        [Required]
        [StringLength(75)]
        public string Remetente_fantasia { get; set; }

        [Required]
        [StringLength(75)]
        public string Remetente_razaosocial { get; set; }

        [Required]
        [StringLength(15)]
        public string Remetente_telefone { get; set; }

        [Required]
        [StringLength(2)]
        public string Remetente_uf { get; set; }
        public string Cod_uf { get; set; }

        public string Remetente_endereco { get; set; }



    }
}
