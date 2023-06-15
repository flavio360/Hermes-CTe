using Ninject;
using System.ServiceProcess;
using WindowsServiceProcessarCTeSP.InjectionsObjects;

namespace WindowsServiceProcessarCTeSP
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
                new ProcessarCTeSP()
                };
                ServiceBase.Run(ServicesToRun);
            }
            else
            {
                var InterfaceTeste = new ProcessarCTeSP();
                InterfaceTeste.ProcessQueue();
            }
        }
    }
}
