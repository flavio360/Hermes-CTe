using HermesService.Application.Interfaces;
using HermesService.Application.Service;
using HermesService.Domain.Entity;
using HermesService.Domain.Interfaces.Repositories.Entity.SICLONET;
using HermesService.Domain.Interfaces.Services;
using HermesService.Domain.Interfaces.Services.WS;
using HermesService.Domain.Service;
using HermesService.Domain.Service.PROC;
using HermesService.Domain.Service.WS.Sefaz;
using HermesService.Infra.Data.Repositories.Entity;
using HermesService.Infra.Data.Repositories.Entity.SICLONET;
using Ninject;
using System.Reflection;

namespace WindowsServiceProcessaCTePR.InjectionsObjects
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

            NinjectKernel.Bind<IProcessaCTeGeraSEFAZApplication>().To<ProcessaCTeGeraSEFAZApplication>();

            //SERVICE

            NinjectKernel.Bind<IRecuperaFiliaisEmissorasAtivasSerivce>().To<RecuperaFiliaisEmissorasAtivasSerivce>();
            NinjectKernel.Bind<IProcessaCTeGeraSEFAZService>().To<ProcessaCTeGeraSEFAZService>();
            NinjectKernel.Bind<IGeraXMLCTeService>().To<GeraXMLCTeService>();
            NinjectKernel.Bind<IMontaXMLCTeService>().To<MontaXMLCTeService>();
            NinjectKernel.Bind<ICommunicationSefazService>().To<CommunicationSefazService>();
            NinjectKernel.Bind<ICte_endereco_web_serviceService>().To<Cte_endereco_web_serviceService>();

            //REPOSITORY
            NinjectKernel.Bind<IEntrega_cte_conifg_filiais_emissorasRepository>().To<Entrega_cte_conifg_filiais_emissorasRepository>();
            NinjectKernel.Bind<IEntityRepository>().To<EntityRepository>();
            NinjectKernel.Bind<IEntregas_cte_dados_gerados_detalheRepository>().To<Entregas_cte_dados_gerados_detalheRepository>();
            NinjectKernel.Bind<IEntregas_cte_envio_ftpRepository>().To<Entregas_cte_envio_ftpRepository>();
            NinjectKernel.Bind<IEntregas_cte_erroRepository>().To<entregas_cte_erroRepository>();
            NinjectKernel.Bind<ICte_endereco_web_serviceRepository>().To<Cte_endereco_web_serviceRepository>();
        }
    }
}
