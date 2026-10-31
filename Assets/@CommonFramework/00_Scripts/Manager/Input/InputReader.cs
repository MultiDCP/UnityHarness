using UnityEngine;

namespace Cappcn.Input
{
    public interface IInputReader
    {
        Vector2 Move { get; }
        bool isJumpPressed { get; }
    }
}