using HermesService.Application.Interfaces;
using HermesService.Application.Service;
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

namespace WindowsServiceRecuperaStatusCTe
{
    partial class RecuperaStatusCTe : ServiceBase
    {
        #region Apllications
        private bool _debugMode = false;

        private IProcessaConsultaCTeSefazApplication _ProcessaConsultaCTeSefazApplication
        {
            get
            {
                return Program.iKernel.Get<IProcessaConsultaCTeSefazApplication>();
            }
        }
        #endregion
        public RecuperaStatusCTe()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
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
        }

        protected override void OnStop()
        {
            // TODO: Add code here to perform any tear-down necessary to stop your service.
        }

        internal void ProcessQueue()
        {
            _ProcessaConsultaCTeSefazApplication.ConsultaStatusCTeSefaz();
        }
    }
}
