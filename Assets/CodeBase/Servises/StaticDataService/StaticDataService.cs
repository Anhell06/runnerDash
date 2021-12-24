namespace Assets.CodeBase.Servises.StaticDataService
{
    public class StaticDataService : IStaticDataService
    {
        private TileStaticData _tiles;
        public TileStaticData Tiles { get => _tiles; }

        public PlayerData playerData => throw new System.NotImplementedException();

        public StaticDataService()
        {
            _tiles = new TileStaticData();
            _tiles.LoadAllTiles();
        }

    }
}
