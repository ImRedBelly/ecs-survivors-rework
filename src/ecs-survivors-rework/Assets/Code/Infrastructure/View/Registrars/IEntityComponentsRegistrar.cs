namespace Code.Infrastructure.View.Registrars
{
    public interface IEntityComponentsRegistrar
    {
        void RegisterComponents();
        void UnregisterComponents();
    }
}