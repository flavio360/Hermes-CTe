using HermesService.Application.EntidadesDTO;
using HermesService.Domain.Entity.EntidadesDTO;
using HermesService.Domain.Entity.SICLONET;
using System;
using System.Collections.Generic;
using System.Text;

namespace HermesService.Domain.Interfaces.Services
{
    public interface IMontaXMLCTeService
    {
        string FormataTagExped(ExpedDTO objExped);
        string FormataTagDest(DestDTO objDest);
        string FormataTagRem(RemDTO objRem);
        string FormataTagIde(IdeDTO objIde);
        string FormataTagImp(ImpDTO objImp);
        string FormataTagEmit(EmitDTO objEmit);
        string FormataTagVPrest(VPrestDTO objVPrest);
        string FormataTagInfCTeNorm(Entregas_cte_dados_gerados_detalhe objDetalhe);
        Tuple<string, string> FormataXMLFinal(string TESTE, string objCompl, string objInfCTeNorm, string objDest,  string objExped, string objRem, string objIde, string objImp, string objEmit, string objVPrest, Entregas_cte_dados_gerados_detalhe objDetalhe, Tuple<string,string,string> propGerais);
        string FormataXMLFinal(string xml, string assinatura, string chaveCTe);
        Tuple<string, string, string> FormataTagXMLCondicional(Entregas_cte_dados_gerados_detalhe objDetalhe);
        Tuple<string, string, string> FormataTagXMLConst(Entregas_cte_dados_gerados_detalhe objDetalhe);
        string AssinaXml(string xmlassinatura);

        string FormataTagComplementar(Entregas_cte_dados_gerados_detalhe objDetalhe);
    }
}
