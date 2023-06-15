
using Hermes.BLL.Ferramentas;
using HermesService.Domain.Context;
using HermesService.Domain.Entity.SICLONET;
using HermesService.Infra.Data.Repositories.Entity.SICLONET;
using Microsoft.VisualStudio.TestTools.UnitTesting;




namespace BankTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void DalSessionConnBaseRetornaOpen()
        {
            var connBase = new DalSession();
            UnitOfWork UoW = connBase.UnitOfWork;
            connBase.UnitOfWork.Dispose();
        }


        [TestMethod]
        public void ConsultaPedidosParaFiladoCTe()
        {
            //var a = new FilaCTeRepository();
            //var ret = a.ConsultaPedidosAsync();
        }


        [TestMethod]
        public void InstanciaECarregaDadonaPropriedaHashSet()
        {
            var entregas = new Entregas();
            


        }

        [TestMethod]
        public void ObtemAlistaDeclientesHabilitadosParaGerarCTe()
        {
            //var cli = new Entregas_cte_filiais_x_remetenteRepository();
            //var ret = cli.ObterClientesHabilitadosCTeAsync();
        }

        [TestMethod]
        public void CalculaDigitoCTe()
        {
            var digitoChaveCTe = new CTeTools();
            var ret = digitoChaveCTe.GerarNumeroCTe("SP", "08957212000505","0","1505", "000000001", "54704126");
            //var cli = new Entregas_cte_filiais_x_remetenteRepository();
            //var ret = cli.ObterClientesHabilitadosCTeAsync();
        }
    }
}
