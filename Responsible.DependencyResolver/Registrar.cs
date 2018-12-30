using Autofac;

namespace Responsible.DependencyResolver
{
    /// <summary>
    /// A class a register dependencies
    /// </summary>
    public abstract class Registrar : Module
    {
        /// <summary>
        /// An inherited method from <see cref="Autofac.Module"/>
        /// Only override <see cref="Load"/> when you wish not to use <see cref="Register"/> function
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            Register(builder);
        }

        /// <summary>
        /// A method to register dependencies
        /// </summary>
        /// <param name="builder"></param>
        protected abstract void Register(ContainerBuilder builder);
    }
}