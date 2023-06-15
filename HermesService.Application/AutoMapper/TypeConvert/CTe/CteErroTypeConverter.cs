using AutoMapper;
using HermesService.Application.EntidadesDTO;
using HermesService.Domain.Entity.SICLONET;
using HermesService.Domain.Entity.SICLONET.PROC;
using System;
using System.Collections.Generic;
using System.Text;

namespace HermesService.Application.AutoMapper.TypeConvert.CTe
{
    public class CteErroTypeConverter : ITypeConverter<List<F_Insere_Fila_CTe>, List<Entregas_cte_erro>>
    {
        public List<Entregas_cte_erro> Convert(List<F_Insere_Fila_CTe> source, List<Entregas_cte_erro> destination, ResolutionContext context)
        {
            if (source == null)
                return null;

            destination = new List<Entregas_cte_erro>();

            foreach (var item in source)
            {
                if (item.Erro)
                {
                    destination.Add(new Entregas_cte_erro()
                    {
                        Id = null,
                        Cod_cte_id = item.Cte_numero,
                        Cod_entrega = item.Cod_entrega,
                        Data_correcao = null,
                        Data_inclusao = DateTime.Now,
                        Observacao_erro = item.DescricaoErro,
                        Usuario_correcao = null
                    });
                }
                
            }
            return destination;
        }
    }
}
