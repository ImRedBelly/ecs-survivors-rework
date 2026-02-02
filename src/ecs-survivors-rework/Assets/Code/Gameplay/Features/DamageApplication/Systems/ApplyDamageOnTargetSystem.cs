using Entitas;

namespace Code.Gameplay.Features.DamageApplication.Systems
{
    public class ApplyDamageOnTargetSystem : IExecuteSystem
    {
        private readonly GameContext _gameContext;
        private readonly IGroup<GameEntity> _damageDealers;

        public ApplyDamageOnTargetSystem(GameContext gameContext)
        {
            _gameContext = gameContext;

            _damageDealers = _gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.TargetsBuffer,
                GameMatcher.Damage
            ));
        }

        public void Execute()
        {
            foreach (var damageDealer in _damageDealers)
            foreach (var targetID in damageDealer.TargetsBuffer)
            {
                var target = _gameContext.GetEntityWithId(targetID);
                if (target.hasCurrentHP)
                {
                    target.ReplaceCurrentHP(target.CurrentHP - damageDealer.Damage);
                    if (target.hasDamageTakenAnimator)
                    {
                        target.DamageTakenAnimator.PlayDamageTaken();
                    }
                }
            }
        }
    }
}