using System;
using Microsoft.EntityFrameworkCore;

namespace Responsible.Uow.EntityFrameworkCore.ConfigurationSupport
{
    /// <summary>
    /// Extension methods for Entity Configuration
    /// </summary>
    public static class EntityMappingExtensions
    {
        /// <summary>
        /// An extension method to Register Entity and It's Configuration
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TMapping"></typeparam>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static ModelBuilder RegisterEntityMapping<TEntity, TMapping>(this ModelBuilder builder)
            where TMapping : IEntityMappingConfiguration<TEntity>
            where TEntity : class
        {
            var mapper = (IEntityMappingConfiguration<TEntity>)Activator.CreateInstance(typeof(TMapping));
            mapper.Map(builder.Entity<TEntity>());
            return builder;
        }
    }
}