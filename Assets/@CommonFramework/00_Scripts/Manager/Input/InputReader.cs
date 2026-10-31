using R3;
using UnityEngine;

namespace Cappcn.Input
{
    public interface IInputReader
    {
        ReadOnlyReactiveProperty<Vector2> Move { get; }
        Observable<Unit> isJumpPressed { get; }
    }
}