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
        internal List<string> RootAssembliesNames { get; private set; } = new List<string>();
        internal List<RegisteredFile> RegisteredAssemblies { get; private set; } = new List<RegisteredFile>();
        internal bool ContainerPrepared { get; private set; }

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
            foreach (var registeredFile in GetAssembliesDetail())
            {
                try
                {
                    builder.RegisterAssemblyModules(Assembly.LoadFrom(registeredFile.Location));
                    RegisteredAssemblies.Add(registeredFile);
                }
                catch (Exception ex)
                {
                    //Could not register assembly
                    System.Diagnostics.Trace.WriteLine(
                        $"{nameof(Resolver)}: Faild to load Assembly - {registeredFile.Name} from {registeredFile.Location} - Exception message: {ex.Message}");
                }
            }

            _container = builder.Build();
            ContainerPrepared = true;
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

        internal void Initialise()
        {
            PrepareContainer();
        }

        #region AssemblyRegisteration

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

        private List<RegisteredFile> GetAssembliesDetail()
        {
            var currentPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var allFiles = GetFilesFromPath(currentPath);
            if (!RootAssembliesNames.Any())
            {
                return allFiles;
            }

            var filtered = from fileToSelect in allFiles
                           from nameToFilter in RootAssembliesNames
                           let lowerNameToFilter = nameToFilter.ToLower()
                           let lowerNameAssemblyToSelect = fileToSelect.Name.ToLower()
                           where lowerNameAssemblyToSelect.StartsWith(lowerNameToFilter)
                           select fileToSelect;
            return filtered.ToList();

        }

        private static List<RegisteredFile> GetFilesFromPath(string path)
        {
            if (path == null)
            {
                return new List<RegisteredFile>();
            }

            var folder = new DirectoryInfo(path);
            var files = new List<FileInfo>();

            var dllFiles = folder.GetFiles("*.dll", SearchOption.TopDirectoryOnly);
            files.AddRange(dllFiles);
            var exeFiles = folder.GetFiles("*.exe", SearchOption.TopDirectoryOnly);
            files.AddRange(exeFiles);

            var result = files.Select(x => new RegisteredFile
            {
                Name = !string.IsNullOrWhiteSpace(x.Name) ? x.Name : string.Empty,
                Location = !string.IsNullOrWhiteSpace(x.FullName) ? x.FullName : string.Empty
            });

            return result.ToList();
        }

        #endregion

        #region Resolvers

        internal T Resolve<T>()
        {
            if (!ContainerPrepared)
            {
                PrepareContainer();
            }

            return Container.Resolve<T>();
        }

        internal bool TryResolve<T>(out T instance)
        {
            if (!ContainerPrepared)
            {
                PrepareContainer();
            }

            return Container.TryResolve(out instance);
        }

        internal T ResolveNamed<T>(string name)
        {
            if (!ContainerPrepared)
            {
                PrepareContainer();
            }

            return Container.ResolveNamed<T>(name);
        }

        internal bool TryResolveNamed<T>(string name, Type serviceType, out T instance)
        {
            if (!ContainerPrepared)
            {
                PrepareContainer();
            }

            try
            {
                var success = Container.TryResolveNamed(name, serviceType, out var resolvedObject);
                if (success)
                {
                    instance = (T)resolvedObject;
                }
                else
                {
                    instance = default(T);
                }

                return success;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(
                    $"{nameof(Resolver)}: Faild to Resolve - {typeof(T).FullName} - Exception Message: {ex.Message}");

                instance = default(T);
                return false;
            }
        }

        #endregion

        internal void Reset()
        {
            ContainerPrepared = false;
            _container = null;
            RootAssembliesNames.Clear();
            RegisteredAssemblies.Clear();
        }

        internal string GetContextDetail()
        {
            var builder = new StringBuilder();
            builder.AppendLine($"{nameof(ContainerPrepared)}: {ContainerPrepared}");
            builder.AppendLine($"{nameof(RootAssembliesNames)}: {string.Join(",", RootAssembliesNames)}");

            if (RegisteredAssemblies.Any())
            {
                builder.AppendLine("Registered Assemblies");
                foreach (var registeredFile in RegisteredAssemblies)
                {
                    builder.AppendLine($"FileName:{registeredFile.Name} - Location: {registeredFile.Location}");
                }
            }
            else
            {
                builder.AppendLine("No Assembly is Registered");
            }

            return builder.ToString();
        }
    }
}
