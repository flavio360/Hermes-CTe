using System;
using System.ServiceProcess;
using System.Configuration;
using HermesService.Application.Utilities;
using HermesService.Application.Interfaces;
using Ninject;

namespace WindowsServiceGeraFilaCTe
{
    public partial class GeraFilaCTe : ServiceBase
    {
        #region Propriedade

        private bool _debugMode = false;

        #endregion


        #region Apllications
        private IProcessaRemessaParaFilaCTeApplication _ProcessaRemessaParaFilaCTeApplication;
        private IProcessaRemessaParaFilaCTeApplication ProcessaRemessaParaFilaCTeApplication
        {            
            get
            {
                return _ProcessaRemessaParaFilaCTeApplication = (_ProcessaRemessaParaFilaCTeApplication != null) ? _ProcessaRemessaParaFilaCTeApplication : Program.iKernel.Get<IProcessaRemessaParaFilaCTeApplication>();
            }
        }
        #endregion

        public GeraFilaCTe()
        {          
            InitializeComponent();
        }

        internal void ProcessQueue()
        {
            ProcessaRemessaParaFilaCTeApplication.ObterClientesEmissoresApplication();
        }
        internal void TestStartupAndStop(string[] args)
        {
            this.OnStart(args);
            Console.ReadLine();
            this.OnStop();
        }
        protected override void OnStart(string[] args)
        {
            try
            {
                if (ConfigurationManager.AppSettings["DEBUG_MODE"] != null)
                    _debugMode = bool.Parse(ConfigurationManager.AppSettings["DEBUG_MODE"]);

                if (_debugMode)
                    System.Diagnostics.Debugger.Launch();

                //this.eventLogGeraFila.WriteEntry("Iniciando Serviço", EventLogEntryType.Information);
                ProcessQueue();
            }
            catch (Exception ex)
            {
                var msgLog = String.Format("OnStart - {0}", ex.Message);
                var log = new GravaLog();
                log.GravarLog(msgLog);
            }
        }

        protected override void OnStop()
        {
        }

        
    }
}
