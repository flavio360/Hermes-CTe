using Ninject;
using System.ServiceProcess;
using WindowsServiceRecuperaStatusCTe.InjectionsObjects;

namespace WindowsServiceRecuperaStatusCTe
{
    static class Program
    {
        public static IKernel iKernel { get; set; }
        static void Main(string[] args)
        {
            iKernel = NinjectConfig.CreateKernel();

            if (!System.Diagnostics.Debugger.IsAttached)
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                new RecuperaStatusCTe()
                };
                ServiceBase.Run(ServicesToRun);
            }
            else
            {
                var InterfaceTeste = new RecuperaStatusCTe();
                InterfaceTeste.ProcessQueue();
            }
        }
    }
}
