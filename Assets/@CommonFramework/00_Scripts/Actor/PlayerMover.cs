using Cappcn.Input;
using UnityEngine;

namespace Cappcn.Actors
{
    public class PlayerMover
    {
        private readonly IInputReader _input;
        public PlayerMover(IInputReader input)
        {
            // 생성자에서 의존성 주입
            _input = input;
        }

        public void Tick(float dt)
        {
            // 이동 처리
            var dir = new Vector3(_input.Move.x, 0, _input.Move.y);
        }
    }
}