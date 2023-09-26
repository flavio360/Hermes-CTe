using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using WindowsServiceAverbacao.InjectionObjetcs;

namespace WindowsServiceAverbacao
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
                new Averbacao()
                };
                ServiceBase.Run(ServicesToRun);
            }
            else
            {
                var InterfaceTeste = new Averbacao();
                InterfaceTeste.ProcessQueue();
            }
        }
    }
}
