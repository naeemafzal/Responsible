using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Responsible.Uow.EntityFrameworkCore
{
    /// <summary>
    /// An instance of ReadonlyRepository for EntityFrameWork implements <see cref="IResponsibleRepository{TEntity}"/>
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class ResponsibleReadonlyRepository<TEntity> : IResponsibleReadonlyRepository<TEntity> where TEntity : class, IReadOnlyEntity
    {
        /// <summary>
        /// Provides a <see cref="DbContext"/> for Querying Entities
        /// </summary>
        public readonly DbContext Context;

        /// <summary>
        /// Creates instance of Generic ResponsibleRepository
        /// </summary>
        /// <param name="context"><see cref="DbContext"/></param>
        protected ResponsibleReadonlyRepository(DbContext context)
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
        public Task<TEntity> GetAsync(CancellationToken cancellationToken = default, params object[] keyValues)
        {
            return Context.Set<TEntity>().FindAsync(cancellationToken, keyValues);
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
        public Task<TEntity> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            return Context.Set<TEntity>().FindAsync(cancellationToken, id);
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
        public Task<TEntity> GetAsync(string id, CancellationToken cancellationToken = default)
        {
            return Context.Set<TEntity>().FindAsync(cancellationToken, id);
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
        public Task<TEntity> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return Context.Set<TEntity>().FindAsync(cancellationToken, id);
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
        public Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return Context.Set<TEntity>().ToListAsync(cancellationToken);
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
        public Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return Context.Set<TEntity>().Where(predicate).ToListAsync(cancellationToken);
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
        public Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return Context.Set<TEntity>().SingleOrDefaultAsync(predicate, cancellationToken);
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
        public Task<TEntity> SingleOrDefaultAsync(CancellationToken cancellationToken = default)
        {
            return Context.Set<TEntity>().SingleOrDefaultAsync(cancellationToken);
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
        public Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return Context.Set<TEntity>().FirstOrDefaultAsync(predicate, cancellationToken);
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
        public Task<TEntity> FirstOrDefaultAsync(CancellationToken cancellationToken = default)
        {
            return Context.Set<TEntity>().FirstOrDefaultAsync(cancellationToken);
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
        public Task<List<TEntity>> QueryAsync(IQueryable<TEntity> query, CancellationToken cancellationToken = default)
        {
            return query.ToListAsync(cancellationToken);
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
        public Task<IQueryable<TEntity>> AsQueryableAsync(CancellationToken cancellationToken = default)
        {
            return Task.Run(() => Context.Set<TEntity>().AsQueryable(), cancellationToken);
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
        public Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return Context.Set<TEntity>().CountAsync(predicate, cancellationToken);
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
        public Task<int> CountAsync(CancellationToken cancellationToken = default)
        {
            return Context.Set<TEntity>().CountAsync(cancellationToken);
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
        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return Context.Set<TEntity>().AnyAsync(predicate, cancellationToken);
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
        public Task<bool> AnyAsync(CancellationToken cancellationToken = default)
        {
            return Context.Set<TEntity>().AnyAsync(cancellationToken);
        }
    }
}