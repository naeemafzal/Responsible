using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Responsible.Core;

namespace Responsible.Uow.EntityFramework
{
    /// <summary>
    /// Implements <see cref="IResponsibleUnitOfWork"/>
    /// </summary>
    public class ResponsibleUnitOfWork : IResponsibleUnitOfWork
    {
        /// <summary>
        /// Current DbContext
        /// </summary>
        public DbContext Context { get; }

        /// <summary>
        /// Creates instance of ResponsibleUnitOfWork, requires as DbContext
        /// </summary>
        /// <param name="context"></param>
        public ResponsibleUnitOfWork(DbContext context)
        {
            Context = context;
        }

        /// <summary>
        /// <para>Submits all changes in the context.</para>
        /// </summary>
        public int SaveChanges()
        {
            return Context.SaveChanges();
        }

        /// <summary>
        /// <para>Submits all changes in the context.</para>
        /// </summary>
        public async Task<int> SaveChangesAsync()
        {
            var readonlyValidationResponse = ValidateReadonlyModels();
            if (!readonlyValidationResponse.Success)
            {
                throw new InvalidOperationException(readonlyValidationResponse.SingleMessage);
            }

            return await Context.SaveChangesAsync();
        }

        /// <summary>
        /// <para>Submits all changes in the context.</para>
        /// </summary>
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            var readonlyValidationResponse = ValidateReadonlyModels();
            if (!readonlyValidationResponse.Success)
            {
                throw new InvalidOperationException(readonlyValidationResponse.SingleMessage);
            }

            return await Context.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// <para>Submits all changes in the context and returns IResponse</para>
        /// </summary>
        public IResponse<int> SaveChangesResponse()
        {
            try
            {
                var readonlyValidationResponse = ValidateReadonlyModels();
                if (!readonlyValidationResponse.Success)
                {
                    return ResponseFactory<int>.Convert(readonlyValidationResponse);
                }

                var save = Context.SaveChanges();
                return ResponseFactory<int>.Ok(save);
            }
            catch (DbEntityValidationException ex)
            {
                var errorMessages = ex.EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => x.ErrorMessage);

                return ResponseFactory<int>.Exception(ex, errorMessages.ToList());
            }
            catch (Exception ex)
            {
                return ResponseFactory<int>.Exception(ex);
            }
        }

        /// <summary>
        /// <para>Submits all changes in the context and returns IResponse</para>
        /// </summary>
        public async Task<IResponse<int>> SaveChangesResponseAsync(CancellationToken cancellationToken)
        {
            try
            {
                //Check if any readonly entities are modified
                var readonlyValidationResponse = ValidateReadonlyModels();
                if (!readonlyValidationResponse.Success)
                {
                    return ResponseFactory<int>.Convert(readonlyValidationResponse);
                }

                var save = await Context.SaveChangesAsync(cancellationToken);
                return ResponseFactory<int>.Ok(save);
            }
            catch (DbEntityValidationException ex)
            {
                var errorMessages = ex.EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => x.ErrorMessage);

                return ResponseFactory<int>.Exception(ex, errorMessages.ToList());
            }
            catch (Exception ex)
            {
                return ResponseFactory<int>.Exception(ex);
            }
        }

        /// <summary>
        /// <para>Submits all changes in the context and returns IResponse</para>
        /// </summary>
        public async Task<IResponse<int>> SaveChangesResponseAsync()
        {
            try
            {
                var readonlyValidationResponse = ValidateReadonlyModels();
                if (!readonlyValidationResponse.Success)
                {
                    return ResponseFactory<int>.Convert(readonlyValidationResponse);
                }

                var save = await Context.SaveChangesAsync();
                return ResponseFactory<int>.Ok(save);
            }
            catch (DbEntityValidationException ex)
            {
                var errorMessages = ex.EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => x.ErrorMessage);

                return ResponseFactory<int>.Exception(ex, errorMessages.ToList());
            }
            catch (Exception ex)
            {
                return ResponseFactory<int>.Exception(ex);
            }
        }

        private IResponse ValidateReadonlyModels()
        {
            //Select all the modified entiries
            var modifiedOrAddedEntities = Context.ChangeTracker.Entries()
                .Where(x => x.State != EntityState.Unchanged)
                .Select(x => x.Entity).ToList();

            var readonlyErrors = modifiedOrAddedEntities.Where(x => x is IReadOnlyEntity)
                .Select(modifiedOrAddedEntity => modifiedOrAddedEntity.GetType().Name).ToList();

            if (!readonlyErrors.Any())
                return ResponseFactory.Ok();

            //Get modification errors
            var errorsGrouped = from x in readonlyErrors
                                group x by x into g
                                let count = g.Count()
                                select new { Value = g.Key, Count = count };
            readonlyErrors = errorsGrouped.Select(x => x.Count > 1
                    ? $"'{x.Count}' Readonly entities of type '{x.Value}' are modified."
                    : $"A Readonly entity of type '{x.Value}' is modified.")
                .ToList();

            return ResponseFactory.Error(readonlyErrors);
        }

        ///<summary>
        ///<para>Disposes the current DbContext</para>
        ///</summary>
        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}