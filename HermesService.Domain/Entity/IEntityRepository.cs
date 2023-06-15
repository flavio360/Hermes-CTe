using HermesService.Domain.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HermesService.Domain.Entity
{
    public interface IEntityRepository : IRepositoryConnection
    {
        /// <summary>
        /// Responsável por inserir entidade através da Tipagem <typeparamref name="T"/> 
        /// </summary>
        /// <typeparam name="T"> Entidade Tipada </typeparam>
        /// <param name="entity"> Objeto que será inserido </param>
        /// <returns> Identity gerado da entidade gravada </returns>
        Task<long> InsertAsync<T>(T entity) where T : class;
        /// <summary>
		/// Responsável por atualizar entidade através da Tipagem <typeparamref name="T"/> 
		/// </summary>
		/// <typeparam name="T"> Entidade Tipada </typeparam>
		/// <param name="entity"> Objeto que será atualizado </param>
		/// <returns> Boolean true para sucesso </returns>
        Task<bool> UpdateAsync<T>(T entity) where T : class;
        /// <summary>
        /// Responsável por obter entidade através da Tipagem <typeparamref name="T"/> 
        /// </summary>
        /// <typeparam name="T"> Entidade Tipada </typeparam>
        /// <param name="id"> Id do objeto buscado </param>
        /// <returns> Entidade Tipada </returns>
        Task<T> GetAsync<T>(long id) where T : class;
        /// <summary>
        /// Responsável por obter todas as entidades através da Tipagem <typeparamref name="T"/> 
        /// </summary>
        /// <typeparam name="T"> Entidade Tipada </typeparam>
        /// <returns> Lista da Entidade Tipada </returns>
        Task<IEnumerable<T>> GetAllAsync<T>() where T : class;


        /// <summary>
        /// Responsável por inserir entidade através da Tipagem <typeparamref name="T"/> 
        /// </summary>
        /// <typeparam name="T"> Entidade Tipada </typeparam>
        /// <param name="entity"> Objeto que será inserido </param>
        /// <returns> Identity gerado da entidade gravada </returns>
        long Insert<T>(T entity) where T : class;
        /// <summary>
		/// Responsável por atualizar entidade através da Tipagem <typeparamref name="T"/> 
		/// </summary>
		/// <typeparam name="T"> Entidade Tipada </typeparam>
		/// <param name="entity"> Objeto que será atualizado </param>
		/// <returns> Boolean true para sucesso </returns>
        bool Update<T>(T entity) where T : class;
        /// <summary>
        /// Responsável por obter entidade através da Tipagem <typeparamref name="T"/> 
        /// </summary>
        /// <typeparam name="T"> Entidade Tipada </typeparam>
        /// <param name="id"> Id do objeto buscado </param>
        /// <returns> Entidade Tipada </returns>
        T Get<T>(long id) where T : class;
        /// <summary>
        /// Responsável por obter todas as entidades através da Tipagem <typeparamref name="T"/> 
        /// </summary>
        /// <typeparam name="T"> Entidade Tipada </typeparam>
        /// <returns> Lista da Entidade Tipada </returns>
        IEnumerable<T> GetAll<T>() where T : class;
    }
}
