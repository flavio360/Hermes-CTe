using HermesService.Application.Interfaces;
using HermesService.Application.Service;
using HermesService.Domain.Entity;
using HermesService.Domain.Interfaces.Repositories.Entity.SICLONET;
using HermesService.Domain.Interfaces.Services;
using HermesService.Domain.Interfaces.Services.WS;
using HermesService.Domain.Service;
using HermesService.Domain.Service.WS.ATM;
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

namespace WindowsServiceAverbacao.InjectionObjetcs
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
            NinjectKernel.Bind<IProcessaAverbacaoApplication>().To<ProcessaAverbacaoApplication>();

            //SERVICE
            NinjectKernel.Bind<IProcessaAverbacaoService>().To<ProcessaAverbacaoService>(); 
            NinjectKernel.Bind<ICarregaPedidosAverbacaoService>().To<CarregaPedidosAverbacaoService>();
            NinjectKernel.Bind<IAutenticacao_info_seguradoraService>().To<Autenticacao_info_seguradoraService>();
            NinjectKernel.Bind<ITokenRequestService>().To<TokenRequestService>();
            NinjectKernel.Bind<IEnviaCTeAverbacaoService>().To<EnviaCTeAverbacaoService>();



            //REPOSITORY
            NinjectKernel.Bind<IEntregas_cte_envio_ftpRepository>().To<Entregas_cte_envio_ftpRepository>();
            NinjectKernel.Bind<IEntityRepository>().To<EntityRepository>();
            NinjectKernel.Bind<IAutenticacao_info_seguradoraRepository>().To<Autenticacao_info_seguradoraRepository>();
            NinjectKernel.Bind<IAverbacaoRepository>().To<AverbacaoRepository>();

            
        }
    }
}
