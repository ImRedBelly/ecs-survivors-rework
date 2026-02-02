using Code.Gameplay.Features.TargetCollection.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.TargetCollection
{
    public class TargetCollectionFeature : Feature
    {
        public TargetCollectionFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<CollectTargetsIntervalSystem>());
            Add(systemFactory.Create<CastForTargetsSystem>());
            
            Add(systemFactory.Create<CleanupTargetBuffersSystem>());
        }
    }
}