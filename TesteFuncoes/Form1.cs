using Hermes.BLL.Ferramentas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TesteFuncoes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var digitoChaveCTe = new CTeTools();
            
            var ret = digitoChaveCTe.GerarNumeroCTe(txtUF.Text, txtCNPJEmitente.Text,txttpEmiss.Text, "1505", txtnumeroCTe.Text,txtCct.Text);

            lblDigitoCte.Text = ret.Substring(43, 1);
            lblChaveCte.Text = ret;
        }
    }
}
