using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Responsible.Uow.EntityFrameworkCore.ConfigurationSupport
{
    /// <summary>
    /// An interface to implement build the Entity Configuration
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEntityMappingConfiguration<T> where T : class
    {
        /// <summary>
        /// Method implemented to create Entity builder
        /// </summary>
        /// <param name="builder"></param>
        void Map(EntityTypeBuilder<T> builder);
    }
}