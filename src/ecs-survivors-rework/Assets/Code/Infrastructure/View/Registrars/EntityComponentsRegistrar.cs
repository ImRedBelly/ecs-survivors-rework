namespace Code.Infrastructure.View.Registrars
{
    public abstract class EntityComponentRegistrar : EntityDependant, IEntityComponentsRegistrar
    {
        public abstract void RegisterComponents();
        public abstract void UnregisterComponents();
    }
}