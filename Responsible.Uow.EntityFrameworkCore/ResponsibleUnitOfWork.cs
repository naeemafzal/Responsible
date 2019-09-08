using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Responsible.Core;

namespace Responsible.Uow.EntityFrameworkCore
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
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var readonlyValidationResponse = ValidateReadonlyModels();
            if (readonlyValidationResponse.Success) return Context.SaveChangesAsync(cancellationToken);

            if (readonlyValidationResponse.HasException)
            {
                throw new InvalidOperationException(readonlyValidationResponse.SingleMessage, readonlyValidationResponse.Exception);
            }
            throw new InvalidOperationException(readonlyValidationResponse.SingleMessage);

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
            //TODO: Replace this a proper exception to extract error detail
            //catch (DbEntityValidationException ex)
            //{
            //    var errorMessages = ex.EntityValidationErrors
            //        .SelectMany(x => x.ValidationErrors)
            //        .Select(x => x.ErrorMessage);

            //    return ResponseFactory<int>.Exception(ex, errorMessages.ToList());
            //}
            catch (Exception ex)
            {
                return ResponseFactory<int>.Exception(ex);
            }
        }

        /// <summary>
        /// <para>Submits all changes in the context and returns IResponse</para>
        /// </summary>
        public async Task<IResponse<int>> SaveChangesResponseAsync(CancellationToken cancellationToken = default)
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
            //TODO: Replace this a proper exception to extract error detail
            //catch (DbEntityValidationException ex)
            //{
            //    var errorMessages = ex.EntityValidationErrors
            //        .SelectMany(x => x.ValidationErrors)
            //        .Select(x => x.ErrorMessage);

            //    return ResponseFactory<int>.Exception(ex, errorMessages.ToList());
            //}
            catch (Exception ex)
            {
                return ResponseFactory<int>.Exception(ex);
            }
        }

        private IResponse ValidateReadonlyModels()
        {
            //Select all the modified entries
            var modifiedOrAddedEntities = Context.ChangeTracker.Entries()
                .Where(x => x.State != EntityState.Unchanged)
                .Select(x => x.Entity).ToList();

            //Custom Code: EFCore does not perform validation so let's do it manually
            foreach (var entity in modifiedOrAddedEntities)
            {
                var validationContext = new ValidationContext(entity);
                Validator.ValidateObject(entity, validationContext);
            }

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