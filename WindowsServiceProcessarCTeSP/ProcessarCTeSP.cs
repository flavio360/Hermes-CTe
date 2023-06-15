using HermesService.Application.Interfaces;
using HermesService.Application.Utilities;
using Ninject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WindowsServiceProcessarCTeSP
{
    public partial class ProcessarCTeSP : ServiceBase
    {
        #region Propriedade

        private bool _debugMode = false;

        #endregion


        #region Apllications

        private IProcessaCTeGeraSEFAZApplication ProcessaCTeGeraSEFAZApplication
        {
            get
            {
                return  Program.iKernel.Get<IProcessaCTeGeraSEFAZApplication>();
            }
        }
        #endregion
        public ProcessarCTeSP()
        {
            InitializeComponent();
        }
        internal void ProcessQueue()
        {
            var empresa = (int)HermesService.Application.Utilities.CTe.CTeEnums.Empresas.SP;

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

        protected override void OnStop()
        {
            // TODO: Add code here to perform any tear-down necessary to stop your service.
        }
    }
}
