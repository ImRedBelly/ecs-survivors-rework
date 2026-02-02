using Code.Gameplay.Common.Time;
using Code.Gameplay.Features.Movement.Systems;

namespace Code.Gameplay.Features.Movement
{
    public class MovementFeature : Feature
    {
        public MovementFeature(GameContext gameContext, ITimeService time)
        {
            Add(new DirectionalDeltaMoveSystem(gameContext, time));
            Add(new UpdateTransformPositionSystem(gameContext));
            Add(new TurnedAlongDirectionSystem(gameContext));
        }
    }
}