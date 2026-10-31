using VContainer;
using VContainer.Unity;
using UnityEngine;
using Cappcn.Input;

public class ProjectLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterEntryPoint<InputManager>();
    }
}
