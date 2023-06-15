using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HermesService.Domain.Context
{
    public sealed class DalSession : IDisposable
	{
		NpgsqlConnection _connection = null;
		readonly UnitOfWork _unitOfWork = null;

		private readonly string _connectionString;
		private bool _disposed;

		public DalSession()
		{
            //_connectionString = ConfigurationManager.AppSettings["connect"].Count().ToString();
            _connectionString = TesteConn.ConnStringa;
			_connection = new NpgsqlConnection(_connectionString);			
			_connection.Open();
            _unitOfWork = new UnitOfWork(_connection);
        }


		public UnitOfWork UnitOfWork
		{
			get { return _unitOfWork; }
		}

		private void dispose(bool disposing)
		{
			if (_disposed)
			{
				return;
			}

			if (disposing)
			{
				_unitOfWork.Dispose();

				if (_connection != null)
				{
					_connection.Dispose();
					_connection = null;
				}
			}
			_disposed = true;
		}

		public void Dispose()
		{
			dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
