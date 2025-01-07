using KeyphPro.Domain.Entities.Commond;
using KeyphPro.Domain.Entities.Database;
using KeyphPro.Domain.Repositories.Queries;
using KeyphPro.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KeyphPro.Infrastructure
{
    /// <summary>
    /// Query repository
    /// </summary>
    /// <typeparam name="TEntity">
    /// The entity type
    /// </typeparam>
    /// <typeparam name="TId">
    /// The id type
    /// </typeparam>
    public class QueryRepository<TEntity, TId> : IQueryRepository<TEntity, TId> where TEntity : class, IEntityBase<TId>
    {
        private readonly KeyphProQueryDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">
        /// The database context
        /// </param>
        public QueryRepository(KeyphProQueryDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        /// <summary>
        /// Get an entity by its id
        /// </summary>
        /// <param name="id">
        /// The id of the entity to get
        /// </param>
        /// <returns>
        /// The entity with the given id
        /// </returns>
        public async Task<TEntity?> GetByIdAsync(TId id)
        {
            return await Task.Run(() =>
            {
                TEntity? entity = _dbSet.Find(id);
                return entity?.Deleted == true ? default : entity;
            });
        }

        /// <summary>
        /// Get all entities
        /// </summary>
        /// <returns>
        /// All entities
        /// </returns>
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Task.Run(() =>
            {
                return _dbSet.Where(x => !x.Deleted).AsEnumerable();
            });
        }

        /// <summary>
        /// Get entities by a dynamic query
        /// </summary>
        /// <param name="predicate">
        /// The expression to filter the entities
        /// </param>
        /// <returns>
        /// A list of filtered entities
        /// </returns>
        public async Task<IEnumerable<TEntity>> GetByQueryAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Task.Run(() =>
            {
                return _dbSet.Where(predicate).Where(x => !x.Deleted).AsEnumerable();
            });
        }

        /// <summary>
        /// Get a single entity by a dynamic query
        /// </summary>
        /// <param name="predicate">
        /// The expression to filter the entity
        /// </param>
        /// <returns>
        /// A single entity matching the query
        /// </returns>
        public async Task<TEntity?> GetSingleByQueryAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Task.Run(() =>
            {
                return _dbSet.Where(predicate).FirstOrDefault(x => !x.Deleted);
            });
        }

        /// <summary>
        /// Ejecuta un script SQL y mapea el resultado a una lista de un modelo específico.
        /// </summary>
        /// <typeparam name="TResult">El tipo del modelo de resultado.</typeparam>
        /// <param name="sqlScript">El script SQL a ejecutar.</param>
        /// <param name="parameters">Parámetros opcionales para el script SQL.</param>
        /// <returns>Lista de resultados mapeados al modelo.</returns>
        public async Task<List<TResult>> ExecuteSqlScriptMappedAsync<TResult>(string sqlScript, params object[] parameters) where TResult : class
        {
            return await _context.Set<TResult>().FromSqlRaw(sqlScript, parameters).ToListAsync();
        }

        /// <summary>
        /// Ejecuta un script almacenado en la tabla StoredScripts y mapea el resultado a un modelo.
        /// </summary>
        /// <typeparam name="TResult">Modelo al que se mapeará el resultado.</typeparam>
        /// <param name="scriptName">Nombre del script en la tabla StoredScripts.</param>
        /// <param name="parameters">Parámetros opcionales para el script SQL.</param>
        /// <returns>Lista de resultados mapeados al modelo.</returns>
        public async Task<List<TResult>> ExecuteStoredScriptMappedAsync<TResult>(string scriptName, Dictionary<string, object> parameters = null) where TResult : class
        {
            // Buscar el script en la tabla StoredScripts
            var storedScript = await _context.Set<StoredScript>().FirstOrDefaultAsync(s => s.Name == scriptName);
            if (storedScript == null)
                throw new KeyNotFoundException($"No se encontró el script con el nombre '{scriptName}'.");

            // Preparar el SQL dinámico
            var sql = storedScript.SqlScript;
            var sqlParameters = new List<object>();

            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    sql = sql.Replace($"@{param.Key}", $"'{param.Value}'"); // Reemplazo básico para SQLite
                }
            }

            // Ejecutar el script SQL
            return await _context.Set<TResult>().FromSqlRaw(sql).ToListAsync();
        }
    }
}
