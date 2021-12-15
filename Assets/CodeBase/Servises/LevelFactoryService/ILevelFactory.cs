namespace Assets.CodeBase.Servises.LevelFactory
{
    public interface ILevelFactory : IService
    {
        void LoadHUD();
        void LoadPlayer();
    }
}