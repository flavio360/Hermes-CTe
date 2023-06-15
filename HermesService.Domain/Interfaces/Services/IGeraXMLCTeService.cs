using HermesService.Application.EntidadesDTO;
using HermesService.Domain.Entity.EntidadesDTO;
using HermesService.Domain.Entity.SICLONET;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace HermesService.Domain.Interfaces.Services
{
    public interface IGeraXMLCTeService
    {
        //Tuple<Entregas_cte_erro, Entregas_cte_transmitido> GeraXMLCTe(ExpedDTO objExped, DestDTO objDest, RemDTO objRem, IdeDTO objIde, ImpDTO objImp, EmitDTO objEmit, VPrestDTO objVPrest , Entregas_cte_dados_gerados_detalhe objDetalhe);
        string GeraXMLCTe(ExpedDTO objExped, DestDTO objDest, RemDTO objRem, IdeDTO objIde, ImpDTO objImp, EmitDTO objEmit, VPrestDTO objVPrest , Entregas_cte_dados_gerados_detalhe objDetalhe, X509Certificate2 cert);

        string GeraXMLCancelamento(InfCTeCancelamentoDTO ObjCancelamento , X509Certificate2 cert);
        string GeraXMLCorrecao(InfCTeCorrecaoDTO ObjCorrecao , Entregas_cte_dados_gerados_detalhe objPedido, X509Certificate2 cert);
    }
}
