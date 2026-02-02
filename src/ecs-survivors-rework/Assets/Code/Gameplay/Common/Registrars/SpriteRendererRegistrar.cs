using Code.Infrastructure.View.Registrars;
using UnityEngine;

namespace Code.Gameplay.Common.Registrars
{
    public class SpriteRendererRegistrar : EntityComponentRegistrar
    {
        public SpriteRenderer SpriteRenderer;

        public override void RegisterComponents()
        {
            GameEntity.AddSpriteRenderer(SpriteRenderer);
        }

        public override void UnregisterComponents()
        {
            if (GameEntity.hasSpriteRenderer)
                GameEntity.RemoveSpriteRenderer();
        }
    }
}