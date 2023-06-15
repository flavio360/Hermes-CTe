using System;
using System.Collections.Generic;
using System.Text;

namespace HermesService.Domain.Entity.SICLONET
{
    public partial class Entregas_recepcao
    {
        public string Codrecepcao { get; set; }
        public string Codentrega { get; set; }
        public DateTime Data_recepcao { get; set; }
        public int Codusuario { get; set; }
        public int Codlog { get; set; }
    }
}
