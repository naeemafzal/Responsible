using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Responsible.Uow.EntityFramework
{
    /// <summary>
    /// Provides an interface for a generaic Repository Entities Querying
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IResponsibleReadonlyRepository<TEntity> 
        where TEntity : class, IReadOnlyEntity
    {
        ///<summary>
        ///<para>Gets a Record By the given primary key values</para>
        ///</summary>
        ///<remarks>
        /// The ordering of composite key values is as defined in the EDM, which is in turn
        ///  as defined in the designer, by the Code First fluent API, or by the DataMember
        ///  attribute.
        /// </remarks>
        TEntity Get(params object[] keyValues);

        ///<summary>
        ///<para>Gets a Record By the given primary key values</para>
        ///</summary>
        ///<remarks>
        /// The ordering of composite key values is as defined in the EDM, which is in turn
        /// as defined in the designer, by the Code First fluent API, or by the DataMember
        /// attribute.
        /// </remarks>
        Task<TEntity> GetAsync(params object[] keyValues);

        ///<summary>
        ///<para>Gets a Record By Id</para>
        ///<para>Must only be used for source with Integer Identity</para>
        ///</summary>
        TEntity Get(int id);

        ///<summary>
        ///<para>Gets a Record By Id</para>
        ///<para>Must only be used for source with Integer Identity</para>
        ///</summary>
        Task<TEntity> GetAsync(int id);

        ///<summary>
        ///<para>Gets a Record By Id</para>
        ///<para>Must only be used for source with string Identity</para>
        ///</summary>
        TEntity Get(string id);

        ///<summary>
        ///<para>Gets a Record By Id</para>
        ///<para>Must only be used for source with string Identity</para>
        ///</summary>
        Task<TEntity> GetAsync(string id);

        ///<summary>
        ///<para>Gets a Record By Id</para>
        ///<para>Must only be used for source with Guid Identity</para>
        ///</summary>
        TEntity Get(Guid id);

        ///<summary>
        ///<para>Gets a Record By Id</para>
        ///<para>Must only be used for source with Guid Identity</para>
        ///</summary>
        Task<TEntity> GetAsync(Guid id);

        ///<summary>
        ///<para>Gets All Record</para>
        ///</summary>
        IEnumerable<TEntity> GetAll();

        ///<summary>
        ///<para>Gets All Record</para>
        ///</summary>
        Task<IEnumerable<TEntity>> GetAllAsync();

        ///<summary>
        ///<para>Finds Record By a predicate</para>
        ///</summary>
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        ///<summary>
        ///<para>Finds Record By a predicate</para>
        ///</summary>
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);

        ///<summary>
        ///<para>Gets SingleOrDefault Record By a predicate</para>
        ///</summary>
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        ///<summary>
        ///<para>Gets SingleOrDefault Record By a predicate</para>
        ///</summary>
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        ///<summary>
        ///<para>Gets SingleOrDefault Record</para>
        ///</summary>
        TEntity SingleOrDefault();

        ///<summary>
        ///<para>Gets SingleOrDefault Record</para>
        ///</summary>
        Task<TEntity> SingleOrDefaultAsync();

        ///<summary>
        ///<para>Gets FirstOrDefault Record By a predicate</para>
        ///</summary>
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);

        ///<summary>
        ///<para>Gets FirstOrDefault Record By a predicate</para>
        ///</summary>
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        ///<summary>
        ///<para>Gets FirstOrDefault Record</para>
        ///</summary>
        TEntity FirstOrDefault();

        ///<summary>
        ///<para>Gets FirstOrDefault Record</para>
        ///</summary>
        Task<TEntity> FirstOrDefaultAsync();

        ///<summary>
        ///<para>Gets Records by IQueryable</para>
        ///</summary>
        IEnumerable<TEntity> Query(IQueryable<TEntity> query);

        ///<summary>
        ///<para>Gets Records by IQueryable</para>
        ///</summary>
        Task<IEnumerable<TEntity>> QueryAsync(IQueryable<TEntity> query);

        ///<summary>
        ///<para>Gets Records by IQueryable</para>
        ///</summary>
        IQueryable<TEntity> AsQueryable();

        ///<summary>
        ///<para>Gets Records by IQueryable</para>
        ///</summary>
        Task<IQueryable<TEntity>> AsQueryableAsync();

        ///<summary>
        ///<para>Gets Count of Record By a predicate</para>
        ///</summary>
        int Count(Expression<Func<TEntity, bool>> predicate);

        ///<summary>
        ///<para>Gets Count of Record By a predicate</para>
        ///</summary>
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);

        ///<summary>
        ///<para>Gets Count of Record</para>
        ///</summary>
        int Count();

        ///<summary>
        ///<para>Gets Count of Record</para>
        ///</summary>
        Task<int> CountAsync();

        ///<summary>
        ///<para>Gets True/False matching records by a predicate</para>
        ///</summary>
        bool Any(Expression<Func<TEntity, bool>> predicate);

        ///<summary>
        ///<para>Gets True/False matching records by a predicate</para>
        ///</summary>
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);

        ///<summary>
        ///<para>Gets True/False of Entities list</para>
        ///</summary>
        bool Any();

        ///<summary>
        ///<para>Gets True/False of Entities list</para>
        ///</summary>
        Task<bool> AnyAsync();
    }
}