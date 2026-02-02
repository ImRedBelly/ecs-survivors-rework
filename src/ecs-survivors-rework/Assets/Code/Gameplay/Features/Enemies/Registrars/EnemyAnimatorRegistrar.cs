using Code.Gameplay.Features.Enemies.Behaviours;
using Code.Infrastructure.View.Registrars;

namespace Code.Gameplay.Features.Enemies.Registrars
{
    public class EnemyAnimatorRegistrar : EntityComponentRegistrar
    {
        public EnemyAnimator EnemyAnimator;

        public override void RegisterComponents()
        {
            GameEntity
                .AddEnemyAnimator(EnemyAnimator)
                .AddDamageTakenAnimator(EnemyAnimator)
                ;
        }

        public override void UnregisterComponents()
        {
            if (GameEntity.hasEnemyAnimator)
                GameEntity.RemoveEnemyAnimator();
            
            if (GameEntity.hasDamageTakenAnimator)
                GameEntity.RemoveDamageTakenAnimator();
        }
    }
}