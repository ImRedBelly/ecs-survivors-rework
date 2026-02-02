using Code.Infrastructure.View.Registrars;

namespace Code.Gameplay.Common.Registrars
{
    public class TransformRegistrar : EntityComponentRegistrar
    {
        public override void RegisterComponents()
        {
            GameEntity.AddTransform(transform);
        }

        public override void UnregisterComponents()
        {
            if (GameEntity.hasTransform)
                GameEntity.RemoveTransform();
        }
    }
}