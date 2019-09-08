using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Responsible.Core;

namespace Responsible.Uow.EntityFrameworkCore
{
    /// <summary>
    /// Provides an interface for EntityFramework UnitOfWork
    /// </summary>
    public interface IResponsibleUnitOfWork : IDisposable
    {
        /// <summary>
        /// Current context DbContext
        /// </summary>
        DbContext Context { get; }

        ///<summary>
        ///<para>Submits all changes in the context.</para>
        ///</summary>
        int SaveChanges();

        ///<summary>
        ///<para>Submits all changes in the context.</para>
        ///</summary>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        ///<summary>
        ///<para>Submits all changes in the context and returns IResponse</para>
        ///</summary>
        IResponse<int> SaveChangesResponse();

        ///<summary>
        ///<para>Submits all changes in the context and returns IResponse</para>
        ///</summary>
        Task<IResponse<int>> SaveChangesResponseAsync(CancellationToken cancellationToken = default);
    }
}