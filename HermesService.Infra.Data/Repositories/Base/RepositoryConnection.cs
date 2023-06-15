using HermesService.Domain.Interfaces.Context;
using HermesService.Domain.Interfaces.Repositories;
using HermesService.Domain.Interfaces.Repositories.Base;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace HermesService.Infra.Data.Repositories.Base
{
    public abstract class RepositoryConnection : IRepositoryConnection
    {
        public NpgsqlConnection Connection { get; set; }
        public NpgsqlTransaction Transaction { get; set; }
        public int TimeOutSQL { get; set; }


        public void InstanciarUnidade(IUnitOfWork UoW)
        {
            Connection = UoW.Connection;
            Transaction = UoW.Transaction;
            TimeOutSQL = 4200;
        }
    }
}
