using Code.Gameplay.Cameras.Provider;
using Code.Gameplay.Common.Time;
using Code.Gameplay.Features.Hero;
using Code.Gameplay.Features.Movement;
using Code.Gameplay.Input;
using Code.Gameplay.Input.Service;

namespace Code.Gameplay
{
    public class BattleFeature : Feature
    {
        public BattleFeature(GameContext gameContext, ITimeService time, IInputService input, ICameraProvider cameraProvider)
        {
            Add(new InputFeature(gameContext, input));

            Add(new HeroFeature(gameContext, cameraProvider));

            Add(new MovementFeature(gameContext, time));
        }
    }
}