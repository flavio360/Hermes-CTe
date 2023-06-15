using HermesService.Application.Interfaces;
using HermesService.Application.Service;
using HermesService.Domain.Entity;
using HermesService.Domain.Interfaces.Repositories;
using HermesService.Domain.Interfaces.Repositories.Entity.SICLONET;
using HermesService.Domain.Interfaces.Services;
using HermesService.Domain.Interfaces.Services.WS;
using HermesService.Domain.Service;
using HermesService.Domain.Service.WS.Sefaz;
using HermesService.Infra.Data.Repositories.Entity;
using HermesService.Infra.Data.Repositories.Entity.SICLONET;
using Ninject;
using System.Reflection;

namespace WindowsServiceRecuperaStatusCTe.InjectionsObjects
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

            NinjectKernel.Bind<IProcessaConsultaCTeSefazApplication>().To<ProcessaConsultaCTeSefazApplication>();


            //SERVICE

            NinjectKernel.Bind<IEntregas_cte_transmitidoService>().To<Entregas_cte_transmitidoService>();
            NinjectKernel.Bind<ICte_endereco_web_serviceService>().To<Cte_endereco_web_serviceService>();
            NinjectKernel.Bind<ICommunicationSefazService>().To<CommunicationSefazService>();
            NinjectKernel.Bind<IObterCertificadoService>().To<ObterCertificadoService>(); 
            NinjectKernel.Bind<IFilaErroCteService>().To<FilaErroCteService>(); 
            NinjectKernel.Bind<IEntregas_cte_envio_ftpService>().To<Entregas_cte_envio_ftpService>();

            //REPOSITORY
            NinjectKernel.Bind<IEntityRepository>().To<EntityRepository>();
            NinjectKernel.Bind<ICte_endereco_web_serviceRepository>().To<Cte_endereco_web_serviceRepository>(); 
            NinjectKernel.Bind<IEntregas_cte_transmitidoRepository>().To<Entregas_cte_transmitidoRepository>(); 
            NinjectKernel.Bind<IFilaErroCteRepository>().To<FilaErroCteRepositoy>();
            NinjectKernel.Bind<IEntregas_cte_envio_ftpRepository>().To<Entregas_cte_envio_ftpRepository>();





        }
    }
}
