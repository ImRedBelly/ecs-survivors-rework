using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Hero.Behaviours;
using UnityEngine;

namespace Code.Gameplay.Features.Hero.Registrars
{
    public class HeroRegistrar : MonoBehaviour
    {
        public float Speed = 2;
        public HeroAnimator HeroAnimator;
       
        public GameEntity _entity;

        private void Awake()
        {
            _entity = CreateEntity.Empty()
                    .AddTransform(transform)
                    .AddHeroAnimator(HeroAnimator)
                    .AddSpriteRenderer(HeroAnimator.SpriteRenderer)
                    .AddWorldPosition(transform.position)
                    .AddDirection(Vector2.zero)
                    .AddSpeed(Speed)
                    .With(x => x.isHero = true)
                    .With(x => x.isTurnedAlongDirection = true)
                ;
        }
    }
}