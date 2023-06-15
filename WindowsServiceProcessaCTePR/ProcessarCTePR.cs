using HermesService.Application.Interfaces;
using HermesService.Application.Utilities;
using System;
using System.Configuration;
using System.ServiceProcess;
using Ninject;

namespace WindowsServiceProcessaCTePR
{
    partial class ProcessarCTePR : ServiceBase
    {
        #region Propriedade

        private bool _debugMode = false;

        #endregion


        #region Apllications

        private IProcessaCTeGeraSEFAZApplication ProcessaCTeGeraSEFAZApplication
        {
            get
            {
                return Program.iKernel.Get<IProcessaCTeGeraSEFAZApplication>();
            }
        }
        public ProcessarCTePR()
        {
            InitializeComponent();
        }

        internal void ProcessQueue()
        {
            var empresa = (int)HermesService.Application.Utilities.CTe.CTeEnums.Empresas.SC;

            ProcessaCTeGeraSEFAZApplication.InstanciaFiliaisEmissoras(empresa.ToString());
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
        #endregion
    }
}
