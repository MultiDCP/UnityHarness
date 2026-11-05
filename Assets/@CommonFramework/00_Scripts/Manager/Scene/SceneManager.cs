using System;
using Cappcn.UI;
using Cysharp.Threading.Tasks;
using R3;
using Unity.VectorGraphics;
using UnityEngine;

namespace Cappcn.Manager
{
    public interface ISceneService
    {
        UniTask LoadSceneAsync(string sceneName);
    }

    public static class SCENE_NAME
    {
        public const string LOADING_SCENE = "Loading";
        public const string GAME_SCENE = "GameScene";
    }

    public sealed class SceneManager : IDisposable, ISceneService, ILoadingSource
    {
        public enum SceneState
        {
            Idle,
            TransitionToLoading,
            LoadingTarget,
            TransitionToTarget,
        }

        private readonly ReactiveProperty<SceneState> _currentState = new(SceneState.Idle);
        private readonly ReactiveProperty<float> _loadingProgress = new(0f);
        public ReadOnlyReactiveProperty<SceneState> CurrentState => _currentState;
        public ReadOnlyReactiveProperty<float> LoadingProgress => _loadingProgress;

        public async UniTask LoadSceneAsync(string sceneName)
        {
            if (SceneState.Idle != _currentState.Value)
            {
                return;
            }

            try
            {
                _currentState.Value = SceneState.TransitionToLoading;
                _loadingProgress.Value = 0;

                await UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(SCENE_NAME.LOADING_SCENE, UnityEngine.SceneManagement.LoadSceneMode.Single);
                _currentState.Value = SceneState.LoadingTarget;

                var loadOp = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName, UnityEngine.SceneManagement.LoadSceneMode.Single);
                loadOp.allowSceneActivation = false;

                while (loadOp.progress < 0.9f)
                {
                    _loadingProgress.Value = loadOp.progress;
                    await UniTask.Yield(PlayerLoopTiming.Update);
                    await UniTask.Delay(1000);
                }

                _loadingProgress.Value = 1f;
                _currentState.Value = SceneState.TransitionToTarget;

                loadOp.allowSceneActivation = true;

                await loadOp;
            }
            finally
            {
                _currentState.Value = SceneState.Idle;
                _loadingProgress.Value = 0;
            }
        }

        public void Dispose()
        {
            _currentState.Dispose();
            _loadingProgress.Dispose();
        }
    }
}