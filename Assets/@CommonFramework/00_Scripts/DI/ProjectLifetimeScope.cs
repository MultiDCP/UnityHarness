using VContainer;
using VContainer.Unity;
using UnityEngine;
using Cappcn.Input;
using Cappcn.Data;
using Cappcn.Manager;

namespace Cappcn.DI
{
    public class ProjectLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<InputManager>();
            builder.Register<DataProvider>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
            builder.Register<OptionManager>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<SceneManager>(Lifetime.Singleton).AsImplementedInterfaces();

            builder.RegisterEntryPoint<ProjectBootStrap>();
        }
    }
}