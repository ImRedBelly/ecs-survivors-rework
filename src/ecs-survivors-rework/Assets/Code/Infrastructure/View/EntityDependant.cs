using UnityEngine;

namespace Code.Infrastructure.View
{
    public abstract class EntityDependant : MonoBehaviour
    {
        public EntityBehaviour EntityView;
        public GameEntity GameEntity => EntityView != null ? EntityView.GameEntity : null;

        private void Awake()
        {
            if (!EntityView)
            {
                EntityView = gameObject.GetComponent<EntityBehaviour>();
            }
        }
    }
}