using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Autofac;

namespace Responsible.DependencyResolver
{
    internal class ResolverContext
    {
        public List<string> RootAssembliesNames { get; private set; } = new List<string>();
        public bool ContainerPrepared { get; private set; }

        private IContainer _container;

        public IContainer Container
        {
            get
            {
                if (ContainerPrepared)
                {
                    return _container;
                }

                PrepareContainer();
                return _container;
            }
        }

        private void PrepareContainer()
        {
            if (ContainerPrepared)
            {
                return;
            }

            var builder = new ContainerBuilder();
            foreach (var assembly in GetAssembliesForContainer())
            {
                builder.RegisterAssemblyModules(assembly);
            }

            _container = builder.Build();
            ContainerPrepared = true;
        }

        private IEnumerable<Assembly> GetAssembliesForContainer()
        {
            if (RootAssembliesNames.Any())
            {
                var allAssembliesInCurrentDomain = AppDomain.CurrentDomain.GetAssemblies();

                //Filter from given Root assembly names
                if (RootAssembliesNames.Any())
                {
                    var filtered =
                        (from assemblyToSelect in allAssembliesInCurrentDomain
                         from nameToFilter in RootAssembliesNames
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

        internal void AssignContainer(IContainer container)
        {
            if (ContainerPrepared)
            {
                throw new InvalidOperationException("The container is already assigned.");
            }

            _container = container ??
                         throw new NullReferenceException("The provided container is null.");
            ContainerPrepared = true;
        }

        internal void SetRootAssemblyNames(params string[] values)
        {
            if (ContainerPrepared)
            {
                throw new InvalidOperationException(
                    "Unable to set Root Assembly names when Context is alread built.");
            }

            if (values == null) return;
            if (!values.Any()) return;


            RootAssembliesNames =
                new List<string>(values.Where(x => !string.IsNullOrWhiteSpace(x)));
        }

        internal void Initialise()
        {
            PrepareContainer();
        }

        internal T Resolve<T>()
        {
            if (!ContainerPrepared)
            {
                PrepareContainer();
            }

            return Container.Resolve<T>();
        }

        internal T ResolveNamed<T>(string name)
        {
            if (!ContainerPrepared)
            {
                PrepareContainer();
            }

            return Container.ResolveNamed<T>(name);
        }

        internal void Reset()
        {
            ContainerPrepared = false;
            _container = null;
        }

        internal string GetContextDetail()
        {
            var builder = new StringBuilder();
            builder.AppendLine($"{nameof(ContainerPrepared)}: {ContainerPrepared}");
            builder.AppendLine($"{nameof(RootAssembliesNames)}: {string.Join(",", RootAssembliesNames)}");

            return builder.ToString();
        }
    }
}
