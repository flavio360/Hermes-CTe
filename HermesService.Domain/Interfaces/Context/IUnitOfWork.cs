using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HermesService.Domain.Interfaces.Context
{
    public interface IUnitOfWork : IDisposable
    {
        bool Disposed { get; }
        Guid Id { get; }
        NpgsqlConnection Connection { get; set; }
        NpgsqlTransaction Transaction { get; }
        void Begin();
        void Commit();
        void Rollback();
    }
}
