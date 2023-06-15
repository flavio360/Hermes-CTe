using Ninject;
using System.ServiceProcess;
using WindowsServiceProcessaCTePR.InjectionsObjects;

namespace WindowsServiceProcessaCTePR
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
                new ProcessarCTePR()
                };
                ServiceBase.Run(ServicesToRun);
            }
            else
            {
                var InterfaceTeste = new ProcessarCTePR();
                InterfaceTeste.ProcessQueue();
            }
        }
    }
}
