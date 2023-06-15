using HermesService.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HermesService.Application.Interfaces
{
    public interface IProcessaCTeGeraSEFAZApplication
    {
        void  InstanciaFiliaisEmissoras(string cod_empresa);
    }
}
