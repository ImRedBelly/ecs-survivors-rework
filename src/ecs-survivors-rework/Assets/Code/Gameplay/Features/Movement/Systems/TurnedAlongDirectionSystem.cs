using Code.Common.Extensions;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class TurnedAlongDirectionSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _movers;

        public TurnedAlongDirectionSystem(GameContext gameContext)
        {
            _movers = gameContext.GetGroup(
                GameMatcher.AllOf(
                    GameMatcher.TurnedAlongDirection,
                    GameMatcher.SpriteRenderer,
                    GameMatcher.Direction));
        }

        public void Execute()
        {
            foreach (var mover in _movers)
            {
                var scale = Mathf.Abs(mover.SpriteRenderer.transform.localScale.x);
                mover.SpriteRenderer.transform
                    .SetScaleX(scale * FaceDirection(mover));
            }
        }

        private float FaceDirection(GameEntity mover)
        {
            return mover.Direction.x < 0 ? -1 : 1;
        }
    }
}