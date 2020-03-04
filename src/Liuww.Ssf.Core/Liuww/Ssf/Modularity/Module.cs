using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace Liuww.Ssf.Modularity
{
    public abstract class Module:
        IModule,
        IOnPreApplicationInitialization,
        IOnApplicationInitialization,
        IOnPostApplicationInitialization,
        IOnApplicationShutdown,
        IPreConfigureServices,
        IPostConfigureServices
    {
        protected internal bool SkipAutoServiceRegistration { get; protected set; }
        private ServiceConfigurationContext _serviceConfigurationContext;
        protected internal ServiceConfigurationContext ServiceConfigurationContext
        {
            get
            {
                if (_serviceConfigurationContext == null)
                {
                    throw new SsfException($"{nameof(ServiceConfigurationContext)} is only available in the {nameof(ConfigureServices)}, {nameof(PreConfigureServices)} and {nameof(PostConfigureServices)} methods.");
                }

                return _serviceConfigurationContext;
            }
            internal set => _serviceConfigurationContext = value;
        }
        public virtual void PreConfigureServices(ServiceConfigurationContext context)
        {

        }
        public virtual void ConfigureServices(ServiceConfigurationContext context)
        {

        }
        public virtual void PostConfigureServices(ServiceConfigurationContext context)
        {

        }
        public virtual void OnPreApplicationInitialization(ApplicationInitializationContext context)
        {

        }
        public virtual void OnApplicationInitialization(ApplicationInitializationContext context)
        {

        }
        public virtual void OnPostApplicationInitialization(ApplicationInitializationContext context)
        {

        }

        public virtual void OnApplicationShutdown(ApplicationShutdownContext context)
        {

        }
        public static bool IsModule(Type type)
        {
            var typeInfo = type.GetTypeInfo();

            return
                typeInfo.IsClass &&
                !typeInfo.IsAbstract &&
                !typeInfo.IsGenericType &&
                typeof(IModule).GetTypeInfo().IsAssignableFrom(type);
        }
        internal static void CheckAbpModuleType(Type moduleType)
        {
            if (!IsModule(moduleType))
            {
                throw new ArgumentException("Given type is not an Ssf module: " + moduleType.AssemblyQualifiedName);
            }
        }

        protected void Configure<TOptions>(Action<TOptions> configureOptions) where TOptions:class
        {
            ServiceConfigurationContext.Services.Configure(configureOptions);
        }
        protected void Configure<TOptions>(string name, Action<TOptions> configureOptions)
            where TOptions : class
        {
            ServiceConfigurationContext.Services.Configure(name, configureOptions);
        }
        protected void Configure<TOptions>(IConfiguration configuration)
            where TOptions : class
        {
            ServiceConfigurationContext.Services.Configure<TOptions>(configuration);
        }
        protected void Configure<TOptions>(IConfiguration configuration, Action<BinderOptions> configureBinder)
            where TOptions : class
        {
            ServiceConfigurationContext.Services.Configure<TOptions>(configuration, configureBinder);
        }

        protected void Configure<TOptions>(string name, IConfiguration configuration)
            where TOptions : class
        {
            ServiceConfigurationContext.Services.Configure<TOptions>(name, configuration);
        }
        protected void PreConfigure<TOptions>(Action<TOptions> configureOptions)
            where TOptions : class
        {
            ServiceConfigurationContext.Services.PreConfigure(configureOptions);
        }

        protected void PostConfigure<TOptions>(Action<TOptions> configureOptions)
            where TOptions : class
        {
            ServiceConfigurationContext.Services.PostConfigure(configureOptions);
        }

        protected void PostConfigureAll<TOptions>(Action<TOptions> configureOptions)
            where TOptions : class
        {
            ServiceConfigurationContext.Services.PostConfigureAll(configureOptions);
        }
    }
}