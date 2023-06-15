using HermesService.Domain.Interfaces.Context;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace HermesService.Domain.Interfaces.Repositories.Base
{
    public interface IRepositoryConnection
    {
        NpgsqlConnection Connection { get; set; }
        NpgsqlTransaction Transaction { get; set; }

        void InstanciarUnidade(IUnitOfWork UoW);
    }
}
