namespace Assets.CodeBase.Servises.StaticDataService
{
    public interface IStaticDataService : IService
    {
        TileStaticData Tiles { get;}
        PlayerData playerData { get;}
    }
}