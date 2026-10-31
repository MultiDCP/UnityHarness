using VContainer;
using VContainer.Unity;
using UnityEngine;
using Cappcn.Camera;
using Unity.Cinemachine;

public class GameSceneScope : LifetimeScope
{
    [SerializeField] private CinemachineCamera _gamePlay;
    [SerializeField] private CinemachineCamera _cinematicCamera;
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<CameraManager>(Lifetime.Singleton)
                .WithParameter("gamePlay", _gamePlay)
                .WithParameter("cinematic", _cinematicCamera);
    }
}
