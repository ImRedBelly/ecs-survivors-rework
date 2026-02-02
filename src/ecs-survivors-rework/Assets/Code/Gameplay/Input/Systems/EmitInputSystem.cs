using Code.Gameplay.Input.Service;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Input.Systems
{
    public class EmitInputSystem : IExecuteSystem
    {
        private readonly IInputService _input;
        private readonly IGroup<GameEntity> _inputs;

        public EmitInputSystem(GameContext game, IInputService input)
        {
            _input = input;
            _inputs = game.GetGroup(GameMatcher.Input);
        }

        public void Execute()
        {
            foreach (var input in _inputs)
            {
                if (_input.HasAxisInput())
                {
                    input.ReplaceAxisInput(new Vector2(_input.GetHorizontalAxis(), _input.GetVerticalAxis()));
                }
                else if (input.hasAxisInput)
                {
                    input.RemoveAxisInput();
                }
            }
        }
    }
}