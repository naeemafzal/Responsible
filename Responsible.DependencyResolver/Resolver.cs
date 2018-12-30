using System;
using System.Collections.Generic;
using System.Linq;
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
        /// Set a flag to extract dependencies from domain
        /// </summary>
        /// <param name="loadFromDomain"></param>
        public static void LoadFromDomain(bool loadFromDomain)
        {
            ResolverContext.ExtractAllAssembliesFromExecutionLocation = loadFromDomain;
        }

        /// <summary>
        /// Set values for Root assemblies. Passing in Microsoft will get all dependencies from Microsoft.*
        /// </summary>
        /// <param name="values"></param>
        public static void SetRootAssemblyNames(params string[] values)
        {
            if (values == null) return;
            if (!values.Any()) return;
            ResolverContext.RootAssembliesNamesToExtractAssembliesFrom =
                new List<string>(values.Where(x => !string.IsNullOrWhiteSpace(x)));
        }

        /// <summary>
        /// Assign a container
        /// </summary>
        /// <param name="container"></param>
        public static void AssignContainer(IContainer container)
        {
            if (ResolverContext.Container != null)
            {
                throw new InvalidOperationException("The container is already assigned.");
            }

            ResolverContext.Container = container;
        }

        /// <summary>
        /// Resolve a type
        /// </summary>
        /// <typeparam name="T">Type to resolve</typeparam>
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
    }
}