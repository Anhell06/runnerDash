namespace Assets.CodeBase.Servises.StaticDataService
{
    public class StaticDataService : IStaticDataService
    {
        private TileStaticData _tiles;
        public TileStaticData Tiles { get => _tiles; }

        public StaticDataService()
        {
            _tiles = new TileStaticData();
            _tiles.LoadAllTiles();
        }

    }
}
