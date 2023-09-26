
namespace WindowsServiceAverbacao
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.serviceProcessInstallerAverbacao = new System.ServiceProcess.ServiceProcessInstaller();
            this.serviceInstallerAverbacao = new System.ServiceProcess.ServiceInstaller();
            // 
            // serviceProcessInstallerAverbacao
            // 
            this.serviceProcessInstallerAverbacao.Password = null;
            this.serviceProcessInstallerAverbacao.Username = null;
            // 
            // serviceInstallerAverbacao
            // 
            this.serviceInstallerAverbacao.ServiceName = "Service1";
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.serviceProcessInstallerAverbacao,
            this.serviceInstallerAverbacao});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller serviceProcessInstallerAverbacao;
        private System.ServiceProcess.ServiceInstaller serviceInstallerAverbacao;
    }
}