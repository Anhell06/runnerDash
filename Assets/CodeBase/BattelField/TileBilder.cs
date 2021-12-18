using Assets.CodeBase.Servises.StaticDataService;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FieldBilder : IFieldBilder
{
    private Tilemap _colisionTileMap;
    private Tilemap _viewTileMap;
    private Tilemap _itemTileMap;
    private IStaticDataService _staticDataService;

    public FieldBilder(Tilemap colisionTileMap, Tilemap viewTileMap, Tilemap itemTileMap, IStaticDataService staticDataService)
    {
        _colisionTileMap = colisionTileMap;
        _viewTileMap = viewTileMap;
        _itemTileMap = itemTileMap;
        _staticDataService = staticDataService;
    }

    public void CreateGameField(MapType forMap, TileObject[,] tiles)
    {
        foreach (var tile in tiles)
        {
            switch (forMap)
            {
                case MapType.Colision:
                    SetTileInField(tile, _colisionTileMap, _staticDataService.Tiles.ColisionTiles);
                    break;
                case MapType.View:
                    SetTileInField(tile, _viewTileMap, _staticDataService.Tiles.ViewTiles);
                    break;
                case MapType.Item:
                    SetTileInField(tile, _itemTileMap, _staticDataService.Tiles.ItemTiles);
                    break;
            }
        }
    }

    private void SetTileInField(TileObject tile, Tilemap map, Dictionary<string, TileBase> FromCollection) =>
        map.SetTile(new Vector3Int(tile.X, tile.Y, 0), FromCollection[tile.TileName]);
}
