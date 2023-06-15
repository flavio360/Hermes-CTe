
namespace WindowsServiceGeraFilaCTe
{
    partial class GeraFilaCTe
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.eventLogGeraFila = new System.Diagnostics.EventLog();
            ((System.ComponentModel.ISupportInitialize)(this.eventLogGeraFila)).BeginInit();
            // 
            // GeraFilaCTe
            // 
            this.ServiceName = "GeraFilaCTe";
            ((System.ComponentModel.ISupportInitialize)(this.eventLogGeraFila)).EndInit();

        }

        #endregion

        private System.Diagnostics.EventLog eventLogGeraFila;
    }
}
