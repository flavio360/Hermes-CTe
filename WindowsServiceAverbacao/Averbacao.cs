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

namespace WindowsServiceAverbacao
{
    partial class Averbacao : ServiceBase
    {
        #region Propriedade

        private bool _debugMode = false;

        private EventLog eventLog;

        #endregion

        #region Apllications
        private IProcessaAverbacaoApplication _ProcessaAverbacaoApplication;
        private IProcessaAverbacaoApplication ProcessaAverbacaoApplication
        {
            get
            {
                return _ProcessaAverbacaoApplication = (_ProcessaAverbacaoApplication != null) ? _ProcessaAverbacaoApplication : Program.iKernel.Get<IProcessaAverbacaoApplication>();
            }
        }
        #endregion
        public Averbacao()
        {
            InitializeComponent();
            eventLog = new EventLog();
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
            eventLog.WriteEntry("O serviço foi interrompido.", EventLogEntryType.Information);
        }

        internal void ProcessQueue()
        {
            ProcessaAverbacaoApplication.ProcessaAverbacaoApplication();
        }
    }
}
