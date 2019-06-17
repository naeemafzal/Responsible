using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Responsible.Uow.EntityFramework
{
    /// <summary>
    /// An instance of Repository for EntityframeWork implements <see cref="IResponsibleRepository{TEntity}"/>
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class ResponsibleRepository<TEntity> : IResponsibleRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Provides a <see cref="DbContext"/> for Querying Entities
        /// </summary>
        public readonly DbContext Context;

        /// <summary>
        /// Creates instance of Generic ResponsibleRepository
        /// </summary>
        /// <param name="context"><see cref="DbContext"/></param>
        protected ResponsibleRepository(DbContext context)
        {
            Context = context;
        }


        /// <summary>
        /// <para>Gets a Record By the given primary key values</para>
        /// </summary>
        /// <remarks>
        /// The ordering of composite key values is as defined in the EDM, which is in turn
        ///  as defined in the designer, by the Code First fluent API, or by the DataMember
        ///  attribute.
        /// </remarks>
        public TEntity Get(params object[] keyValues)
        {
            return Context.Set<TEntity>().Find(keyValues);
        }


        /// <summary>
        /// <para>Gets a Record By the given primary key values</para>
        /// </summary>
        /// <remarks>
        /// The ordering of composite key values is as defined in the EDM, which is in turn
        /// as defined in the designer, by the Code First fluent API, or by the DataMember
        /// attribute.
        /// </remarks>
        public async Task<TEntity> GetAsync(params object[] keyValues)
        {
            return await Context.Set<TEntity>().FindAsync(keyValues);
        }


        /// <summary>
        /// <para>Gets a Record By Id</para>
        /// <para>Must only be used for source with Integer Identity</para>
        /// </summary>
        public TEntity Get(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }


        /// <summary>
        /// <para>Gets a Record By Id</para>
        /// <para>Must only be used for source with Integer Identity</para>
        /// </summary>
        public async Task<TEntity> GetAsync(int id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }


        /// <summary>
        /// <para>Gets a Record By Id</para>
        /// <para>Must only be used for source with string Identity</para>
        /// </summary>
        public TEntity Get(string id)
        {
            return Context.Set<TEntity>().Find(id);
        }


        /// <summary>
        /// <para>Gets a Record By Id</para>
        /// <para>Must only be used for source with string Identity</para>
        /// </summary>
        public async Task<TEntity> GetAsync(string id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }


        /// <summary>
        /// <para>Gets a Record By Id</para>
        /// <para>Must only be used for source with Guid Identity</para>
        /// </summary>
        public TEntity Get(Guid id)
        {
            return Context.Set<TEntity>().Find(id);
        }


        /// <summary>
        /// <para>Gets a Record By Id</para>
        /// <para>Must only be used for source with Guid Identity</para>
        /// </summary>
        public async Task<TEntity> GetAsync(Guid id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }


        /// <summary>
        /// <para>Gets All Record</para>
        /// </summary>
        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }


        /// <summary>
        /// <para>Gets All Record</para>
        /// </summary>
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }


        /// <summary>
        /// <para>Finds Record By a predicate</para>
        /// </summary>
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate).ToList();
        }


        /// <summary>
        /// <para>Finds Record By a predicate</para>
        /// </summary>
        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.Set<TEntity>().Where(predicate).ToListAsync();
        }


        /// <summary>
        /// <para>Gets SingleOrDefault Record By a predicate</para>
        /// </summary>
        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().SingleOrDefault(predicate);
        }


        /// <summary>
        /// <para>Gets SingleOrDefault Record By a predicate</para>
        /// </summary>
        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.Set<TEntity>().SingleOrDefaultAsync(predicate);
        }


        /// <summary>
        /// <para>Gets SingleOrDefault Record</para>
        /// </summary>
        public TEntity SingleOrDefault()
        {
            return Context.Set<TEntity>().SingleOrDefault();
        }


        /// <summary>
        /// <para>Gets SingleOrDefault Record</para>
        /// </summary>
        public async Task<TEntity> SingleOrDefaultAsync()
        {
            return await Context.Set<TEntity>().SingleOrDefaultAsync();
        }

        /// <summary>
        /// <para>Gets FirstOrDefault Record By a predicate</para>
        /// </summary>
        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().FirstOrDefault(predicate);
        }


        /// <summary>
        /// <para>Gets FirstOrDefault Record By a predicate</para>
        /// </summary>
        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }


        /// <summary>
        /// <para>Gets FirstOrDefault Record</para>
        /// </summary>
        public TEntity FirstOrDefault()
        {
            return Context.Set<TEntity>().FirstOrDefault();
        }


        /// <summary>
        /// <para>Gets FirstOrDefault Record</para>
        /// </summary>
        public async Task<TEntity> FirstOrDefaultAsync()
        {
            return await Context.Set<TEntity>().FirstOrDefaultAsync();
        }


        /// <summary>
        /// <para>Gets Records by IQueryable</para>
        /// </summary>
        public IEnumerable<TEntity> Query(IQueryable<TEntity> query)
        {
            return query.ToList();
        }


        /// <summary>
        /// <para>Gets Records by IQueryable</para>
        /// </summary>
        public async Task<IEnumerable<TEntity>> QueryAsync(IQueryable<TEntity> query)
        {
            return await query.ToListAsync();
        }


        /// <summary>
        /// <para>Gets Records by IQueryable</para>
        /// </summary>
        public IQueryable<TEntity> AsQueryable()
        {
            return Context.Set<TEntity>().AsQueryable();
        }


        /// <summary>
        /// <para>Gets Records by IQueryable</para>
        /// </summary>
        public async Task<IQueryable<TEntity>> AsQueryableAsync()
        {
            return await Task.Run(() => Context.Set<TEntity>().AsQueryable());
        }


        /// <summary>
        /// <para>Gets Count of Record By a predicate</para>
        /// </summary>
        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Count(predicate);
        }


        /// <summary>
        /// <para>Gets Count of Record By a predicate</para>
        /// </summary>
        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.Set<TEntity>().CountAsync(predicate);
        }


        /// <summary>
        /// <para>Gets Count of Record</para>
        /// </summary>
        public int Count()
        {
            return Context.Set<TEntity>().Count();
        }


        /// <summary>
        /// <para>Gets Count of Record</para>
        /// </summary>
        public async Task<int> CountAsync()
        {
            return await Context.Set<TEntity>().CountAsync();
        }


        /// <summary>
        /// <para>Gets True/False matching records by a predicate</para>
        /// </summary>
        public bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Any(predicate);
        }


        /// <summary>
        /// <para>Gets True/False matching records by a predicate</para>
        /// </summary>
        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.Set<TEntity>().AnyAsync(predicate);
        }


        /// <summary>
        /// <para>Gets True/False of Entities list</para>
        /// </summary>
        public bool Any()
        {
            return Context.Set<TEntity>().Any();
        }
        
        /// <summary>
        /// <para>Gets True/False of Entities list</para>
        /// </summary>
        public async Task<bool> AnyAsync()
        {
            return await Context.Set<TEntity>().AnyAsync();
        }

        /// <summary>
        /// <para>Adds a Record</para>
        /// <para>All required properties must be provided</para>
        /// </summary>
        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }
        
        /// <summary>
        /// <para>Adds a Record</para>
        /// <para>All required properties must be provided</para>
        /// </summary>
        public async Task AddAsync(TEntity entity)
        {
            await Task.Run(() => Context.Set<TEntity>().Add(entity));
        }


        /// <summary>
        /// <para>Adds Multiple Record</para>
        /// <para>All required properties must be provided</para>
        /// </summary>
        public void AddRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);
        }


        /// <summary>
        /// <para>Adds Multiple Record</para>
        /// <para>All required properties must be provided</para>
        /// </summary>
        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await Task.Run(() => Context.Set<TEntity>().AddRange(entities));
        }


        /// <summary>
        /// <para>Removes a Record</para>
        /// <para>Record must be loaded from database first</para>
        /// </summary>
        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }


        /// <summary>
        /// <para>Removes a Record</para>
        /// <para>Record must be loaded from database first</para>
        /// </summary>
        public async Task RemoveAsync(TEntity entity)
        {
            await Task.Run(() => Context.Set<TEntity>().Remove(entity));
        }


        /// <summary>
        /// <para>Removes multiple Record</para>
        /// <para>Records must be loaded from database first</para>
        /// </summary>
        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }


        /// <summary>
        /// <para>Removes multiple Record</para>
        /// <para>Records must be loaded from database first</para>
        /// </summary>
        public async Task RemoveRangeAsync(IEnumerable<TEntity> entities)
        {
            await Task.Run(() => Context.Set<TEntity>().RemoveRange(entities));
        }
    }
}