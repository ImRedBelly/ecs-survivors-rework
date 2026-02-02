using Code.Common.Destruct.Systems;
using Code.Infrastructure.Systems;

namespace Code.Common.Destruct
{
    public class ProcessDestructedFeature : Feature
    {
        public ProcessDestructedFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<SelfDestructionTimerSystem>());
            
            Add(systemFactory.Create<CleanupGameDestructedViewSystem>());
            Add(systemFactory.Create<CleanupGameDestructedSystem>());
        }
    }
}