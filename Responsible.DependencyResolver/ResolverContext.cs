using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Autofac;

namespace Responsible.DependencyResolver
{
    internal class ResolverContext
    {
        public bool ExtractAllAssembliesFromExecutionLocation { get; set; }
        public List<string> RootAssembliesNamesToExtractAssembliesFrom { get; set; } = new List<string>();
        private IContainer _container;

        public IContainer Container
        {
            get
            {
                if (_container != null)
                {
                    return _container;
                }

                PrepareContainer();
                return _container;
            }
            set => _container = value;
        }

        internal void PrepareContainer()
        {
            if (_container != null)
            {
                return;
            }

            var builder = new ContainerBuilder();
            foreach (var assembly in GetAssembliesForContainer())
            {
                builder.RegisterAssemblyModules(assembly);
            }

            Container = builder.Build();
        }

        private IEnumerable<Assembly> GetAssembliesForContainer()
        {
            if (ExtractAllAssembliesFromExecutionLocation)
            {
                var allAssembliesInCurrentDomain = AppDomain.CurrentDomain.GetAssemblies();

                //Filter from given Root assembly names
                if (RootAssembliesNamesToExtractAssembliesFrom.Any())
                {
                    var filtered =
                        (from assemblyToSelect in allAssembliesInCurrentDomain
                         from nameToFilter in RootAssembliesNamesToExtractAssembliesFrom
                         let lowerNameToFilter = nameToFilter.ToLower()
                         let lowerNameAssemblyToSelect = assemblyToSelect.FullName.ToLower()
                         where lowerNameAssemblyToSelect.StartsWith(lowerNameToFilter)
                         select assemblyToSelect);
                    return filtered;
                }

                //Get all assemblies in the current domain
                return allAssembliesInCurrentDomain;
            }

            //Get all assemblies in the  execution location
            var currentPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (currentPath == null)
            {
                throw new NullReferenceException(
                    $"Could not load detail from:" +
                    $" '{nameof(Assembly.GetExecutingAssembly)}' about the current execution location.");
            }


            var folder = new DirectoryInfo(currentPath);
            var files = new List<FileInfo>();

            var dllFiles = folder.GetFiles("*.dll", SearchOption.TopDirectoryOnly);
            files.AddRange(dllFiles);
            var exeFiles = folder.GetFiles("*.exe", SearchOption.TopDirectoryOnly);
            files.AddRange(exeFiles);

            return files.Select(x => Assembly.LoadFrom(x.FullName));
        }

        internal T Resolve<T>()
        {
            if (_container == null)
            {
                PrepareContainer();
            }

            return Container.Resolve<T>();
        }

        internal T ResolveNamed<T>(string name)
        {
            if (_container == null)
            {
                PrepareContainer();
            }

            return Container.ResolveNamed<T>(name);
        }

        internal void Reset()
        {
            _container = null;
            ExtractAllAssembliesFromExecutionLocation = false;
            RootAssembliesNamesToExtractAssembliesFrom = new List<string>();
        }
    }
}
