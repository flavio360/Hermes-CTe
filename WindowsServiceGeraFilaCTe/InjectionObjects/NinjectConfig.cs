using HermesService.Application.Interfaces;
using HermesService.Application.Service;
using HermesService.Application.Utilities.CTe;
using HermesService.Domain.Entity;
using HermesService.Domain.Interfaces.Repositories.Entity.SICLONET;
using HermesService.Domain.Interfaces.Repositories.Entity.SICLONET.PROC;
using HermesService.Domain.Interfaces.Services;
using HermesService.Domain.Interfaces.Services.PROC;
using HermesService.Domain.Service;
using HermesService.Domain.Service.Base;
using HermesService.Domain.Service.PROC;
using HermesService.Infra.Data.Repositories.Entity;
using HermesService.Infra.Data.Repositories.Entity.SICLONET;
using HermesService.Infra.Data.Repositories.Entity.SICLONET.PROC;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WindowsServiceGeraFilaCTe.InjectionObjects
{
    public class NinjectConfig
    {
        public static StandardKernel NinjectKernel { get; private set; }

        public static IKernel CreateKernel()
        {
            NinjectKernel = new StandardKernel();
            RegisterServices(NinjectKernel);

            return NinjectKernel;
        }


        private static void RegisterServices(IKernel kernel)
        {
            kernel.Load(Assembly.GetExecutingAssembly());

            //APPLICATION

            NinjectKernel.Bind<IProcessaRemessaParaFilaCTeApplication>().To<ProcessaRemessaParaFilaCTeApplication>();


            // SERVICES

            NinjectKernel.Bind<IProcessaRemessaParaFilaCTeService>().To<ProcessaRemessaParaFilaCTeService>();
            NinjectKernel.Bind<IObeterPedidosService>().To<ObterPedidosService>();
            NinjectKernel.Bind<IFilaErroCteService>().To<FilaErroCteService>();
            NinjectKernel.Bind<IF_Roteirizador_EntregaService>().To<F_Roteirizador_EntregaService>();
            NinjectKernel.Bind<IF_Insere_Fila_CTeService>().To<F_Insere_Fila_CTeService>();
            NinjectKernel.Bind<IEntregas_codigos_cidades_ibgeService>().To<Entregas_codigos_cidades_ibgeService>();
            NinjectKernel.Bind<IF_Calcula_Frete_Tributos_EcommerceService>().To<F_Calcula_Frete_Tributos_EcommerceService>();


            // REPOSITORY

            NinjectKernel.Bind<IProcessaRemessaParaFilaCTeRepository>().To<ProcessaRemessaParaFilaCTeRepository>();
            NinjectKernel.Bind<IFilaCTeRepository>().To<FilaCTeRepository>();
            NinjectKernel.Bind<IEntityRepository>().To<EntityRepository>();
            NinjectKernel.Bind<IFilaErroCteRepository>().To<FilaErroCteRepositoy>();
            NinjectKernel.Bind<IF_Roteirizador_EntregasRepository>().To<F_Roteirizador_EntregasRepository>();
            NinjectKernel.Bind<IF_Insere_Fila_CTeRepository>().To<F_Insere_Fila_CTeRepository>();
            NinjectKernel.Bind<IEntregas_codigos_cidades_ibgeRepository>().To<Entregas_codigos_cidades_ibgeRepository>();
            NinjectKernel.Bind<IF_Calcula_Frete_Tributos_EcommerceRepository>().To<F_Calcula_Frete_Tributos_EcommerceRepository>();

        }
    }
}
