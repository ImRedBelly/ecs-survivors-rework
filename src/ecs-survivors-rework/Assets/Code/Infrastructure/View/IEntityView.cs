using UnityEngine;

namespace Code.Infrastructure.View
{
    public interface IEntityView
    {
        GameEntity GameEntity { get; }
        GameObject GameObject { get; }
        void SetEntity(GameEntity entity);
        void ReleaseEntity();
    }
}