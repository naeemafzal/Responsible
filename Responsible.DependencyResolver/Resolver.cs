using Autofac;

namespace Responsible.DependencyResolver
{
    /// <summary>
    /// A static class proving support to Register/Resolve dependencies
    /// </summary>
    public static class Resolver
    {
        private static readonly ResolverContext ResolverContext = new ResolverContext();

        /// <summary>
        /// Get the underlining <see cref="Autofac.IContainer"/>
        /// </summary>
        public static IContainer Container => ResolverContext.Container;

        /// <summary>
        /// Set values for Root assemblies. Passing in Micr will register all <see cref="Module"/> and <see cref="Registrar"/> from Micr*
        /// </summary>
        /// <param name="values"></param>
        public static void SetRootAssemblyNames(params string[] values)
        {
            ResolverContext.SetRootAssemblyNames(values);
        }

        /// <summary>
        /// Prepares the underlining <see cref="Autofac.IContainer"/> 
        /// </summary>
        public static void Initialise()
        {
            ResolverContext.Initialise();
        }

        /// <summary>
        /// Assign a container
        /// </summary>
        /// <param name="container"></param>
        public static void AssignContainer(IContainer container)
        {
            ResolverContext.AssignContainer(container);
        }

        /// <summary>
        /// Resolve a type
        /// </summary>
        /// <typeparam name="T">Type to resolve</typeparam>
        /// <exception cref="Autofac.Core.Registration.ComponentNotRegisteredException">Thrown when the requested Component cannot be resolved</exception>
        /// <returns>Resolved Type</returns>
        public static T Resolve<T>()
        {
            return ResolverContext.Resolve<T>();
        }

        /// <summary>
        /// Resolve a type by name
        /// </summary>
        /// <typeparam name="T">Type to resolve</typeparam>
        /// <param name="name">Name used to resolve the type</param>
        /// <exception cref="Autofac.Core.Registration.ComponentNotRegisteredException">Thrown when the requested Component cannot be resolved</exception>
        /// <returns>Resolved Type</returns>
        public static T ResolveNamed<T>(string name)
        {
            return ResolverContext.ResolveNamed<T>(name);
        }

        /// <summary>
        /// Reset the Resolve Context
        /// </summary>
        public static void Reset()
        {
            ResolverContext.Reset();
        }

        /// <summary>
        /// Gets detail of Current Resolver Context
        /// </summary>
        /// <returns></returns>
        public static string GetContextDetail()
        {
            return ResolverContext.GetContextDetail();
        }
    }
}