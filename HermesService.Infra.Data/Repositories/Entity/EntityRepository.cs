using HermesService.Domain.Entity;
using HermesService.Infra.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;


namespace HermesService.Infra.Data.Repositories.Entity
{
	public class EntityRepository : RepositoryConnection, IEntityRepository
	{
		/// <summary>
		/// Responsável por inserir entidade através da Tipagem <typeparamref name="T"/> 
		/// </summary>
		/// <typeparam name="T"> Entidade Tipada </typeparam>
		/// <param name="entity"> Objeto que será inserido </param>
		/// <returns> Identity gerado da entidade gravada </returns>
		public async Task<long> InsertAsync<T>(T entity) where T : class
		{
			try
			{
				if (entity == null)
					throw new ArgumentNullException(entity.ToString());

				var identity = await Connection.InsertAsync<T>(entity, Transaction);
				return identity;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// Responsável por inserir entidade através da Tipagem <typeparamref name="T"/> 
		/// </summary>
		/// <typeparam name="T"> Entidade Tipada </typeparam>
		/// <param name="entity"> Objeto que será inserido </param>
		/// <returns> Identity gerado da entidade gravada </returns>
		public long Insert<T>(T entity) where T : class
		{
			try
			{
				if (entity == null)
					throw new ArgumentNullException(entity.ToString());

				var identity = Connection.Insert<T>(entity, Transaction);
				return identity;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// Responsável por atualizar entidade através da Tipagem <typeparamref name="T"/> 
		/// </summary>
		/// <typeparam name="T"> Entidade Tipada </typeparam>
		/// <param name="entity"> Objeto que será atualizado </param>
		/// <returns> Boolean true para sucesso </returns>
		public async Task<bool> UpdateAsync<T>(T entity) where T : class
		{
			try
			{
				if (entity == null)
					throw new ArgumentNullException(entity.ToString());

				var isSuccess = await Connection.UpdateAsync<T>(entity, Transaction);

				return isSuccess;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// Responsável por atualizar entidade através da Tipagem <typeparamref name="T"/> 
		/// </summary>
		/// <typeparam name="T"> Entidade Tipada </typeparam>
		/// <param name="entity"> Objeto que será atualizado </param>
		/// <returns> Boolean true para sucesso </returns>
		public bool Update<T>(T entity) where T : class
		{
			try
			{
				if (entity == null)
					throw new ArgumentNullException(entity.ToString());

				var isSuccess = Connection.Update<T>(entity, Transaction);

				return isSuccess;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// Responsável por obter entidade através da Tipagem <typeparamref name="T"/> 
		/// </summary>
		/// <typeparam name="T"> Entidade Tipada </typeparam>
		/// <param name="id"> Id do objeto buscado </param>
		/// <returns> Entidade Tipada </returns>
		public async Task<T> GetAsync<T>(long id) where T : class
		{
			try
			{
				var entity = await Connection.GetAsync<T>(id, Transaction);
				return entity;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// Responsável por obter entidade através da Tipagem <typeparamref name="T"/> 
		/// </summary>
		/// <typeparam name="T"> Entidade Tipada </typeparam>
		/// <param name="id"> Id do objeto buscado </param>
		/// <returns> Entidade Tipada </returns>
		public T Get<T>(long id) where T : class
		{
			try
			{
				var entity = Connection.Get<T>(id, Transaction);
				return entity;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// Responsável por obter todas as entidades através da Tipagem <typeparamref name="T"/> 
		/// </summary>
		/// <typeparam name="T"> Entidade Tipada </typeparam>
		/// <returns> Lista da Entidade Tipada </returns>
		public async Task<IEnumerable<T>> GetAllAsync<T>() where T : class
		{
			try
			{
				var entities = await Connection.GetAllAsync<T>(Transaction);
				return entities;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// Responsável por obter todas as entidades através da Tipagem <typeparamref name="T"/> 
		/// </summary>
		/// <typeparam name="T"> Entidade Tipada </typeparam>
		/// <returns> Lista da Entidade Tipada </returns>
		public IEnumerable<T> GetAll<T>() where T : class
		{
			try
			{
				var entities = Connection.GetAll<T>(Transaction);
				return entities;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null) where T : class
		{
			try
			{
				var entities = await Connection.QueryAsync<T>(sql: sql, param: param);
				return entities;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public async Task<T> QueryFirstDefaultAsync<T>(string sql, object param = null) where T : class
		{
			try
			{
				var entities = await Connection.QueryFirstOrDefaultAsync<T>(sql: sql, param: param);
				return entities;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

	}
}
