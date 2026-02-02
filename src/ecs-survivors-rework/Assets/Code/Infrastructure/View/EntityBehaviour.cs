using Code.Gameplay.Common.Collisions;
using Code.Infrastructure.View.Registrars;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.View
{
    public class EntityBehaviour : MonoBehaviour, IEntityView
    {
        public GameEntity GameEntity => _entity;
        public GameObject GameObject => gameObject;

        private GameEntity _entity;
        private ICollisionRegistry _collisionRegistry;

        [Inject]
        private void Construct(ICollisionRegistry collisionRegistry)
        {
            _collisionRegistry = collisionRegistry;
        }

        public void SetEntity(GameEntity entity)
        {
            _entity = entity;
            _entity.AddView(this);
            _entity.Retain(this);

            foreach (var registrar in GetComponentsInChildren<IEntityComponentsRegistrar>())
                registrar.RegisterComponents();

            foreach (var inCollider in GetComponentsInChildren<Collider2D>(includeInactive: true))
                _collisionRegistry.Register(inCollider.GetInstanceID(), _entity);
        }

        public void ReleaseEntity()
        {
            foreach (var registrar in GetComponentsInChildren<IEntityComponentsRegistrar>())
                registrar.UnregisterComponents();

            foreach (var inCollider in GetComponentsInChildren<Collider2D>(includeInactive: true))
                _collisionRegistry.Unregister(inCollider.GetInstanceID());

            _entity.Release(this);
            _entity = null;
        }
    }
}