using VContainer;
using VContainer.Unity;
using UnityEngine;
using Cappcn.Input;
using Cappcn.Data;
using Cappcn.Manager;

public class ProjectLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterEntryPoint<InputManager>();
        builder.Register<DataProvider>(Lifetime.Singleton);
        builder.RegisterEntryPoint<OptionManager>(Lifetime.Singleton);
    }
}
