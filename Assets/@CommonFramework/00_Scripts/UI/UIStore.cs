using System;
using System.Collections.Generic;
using R3;
using UnityEngine;

namespace Cappcn.DataStore
{
    public enum EUIType
    {
        HUD,
    }

    public interface IUIReader
    {
        ReadOnlyReactiveProperty<bool> GetVisible(EUIType type);
    }

    public interface IUIWriter
    {
        void Show(EUIType type);
        void Hide(EUIType type);
    }

    public sealed class UIStore : IDisposable, IUIReader, IUIWriter
    {
        private readonly Dictionary<EUIType, ReactiveProperty<bool>> _uiStore = new()
        {
            {EUIType.HUD, new()},
        };

        public ReadOnlyReactiveProperty<bool> GetVisible(EUIType type) => _uiStore[type];

        public void Show(EUIType type) => _uiStore[type].Value = true;
        public void Hide(EUIType type) => _uiStore[type].Value = false;

        public void Dispose()
        {
            foreach(var ui in _uiStore.Values)
            {
                ui.Dispose();
            }
        }
    }
}