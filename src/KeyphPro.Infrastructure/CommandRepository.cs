using Microsoft.EntityFrameworkCore;
using KeyphPro.Domain.Entities.Commond;
using KeyphPro.Domain.Repositories.Commands;
using KeyphPro.Infrastructure.Data;
using KeyphPro.Domain.Entities.Database;

namespace KeyphPro.Infrastructure
{
    /// <summary>
    /// Command Repository
    /// </summary>
    /// <typeparam name="TEntity">
    /// Entity
    /// </typeparam>
    /// <typeparam name="TId">
    /// Id of the entity
    /// </typeparam>
    public class CommandRepository<TEntity, TId> : ICommandRepository<TEntity, TId> where TEntity : class, IEntityBase<TId>
    {
        private readonly KeyphProCommandDbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">
        /// StoreDBContext
        /// </param>
        public CommandRepository(KeyphProCommandDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }
        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity">
        /// Entity to update
        /// </param>
        /// <returns>
        /// True if the entity was updated
        /// </returns>
        public async Task<bool> UpdateAsync(TEntity entity)
        {
            return await Task.Run(() =>
             {
                 _context.Entry(entity).State = EntityState.Modified;
                 return true;
             });
        }
        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity">
        /// Entity to delete
        /// </param>
        /// <returns>
        /// True if the entity was deleted
        /// </returns>
        public async Task<bool> DeleteAsync(TEntity entity)
        {
            return await Task.Run(() =>
            {
                entity.Deleted = true;
                _context.Entry(entity).State = EntityState.Modified;
                return entity.Deleted;
            });
        }
        /// <summary>
        /// Create entity
        /// </summary>
        /// <param name="entity">
        /// Entity to create
        /// </param>
        /// <returns>
        /// Id of the entity created
        /// </returns>
        public async Task<TId> CreateAsync(TEntity entity)
        {
            return await Task.Run(() =>
            {
                _context.Add(entity);
                return entity.Id;
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

        /// <summary>
        /// Saves the changes.
        /// </summary>
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
