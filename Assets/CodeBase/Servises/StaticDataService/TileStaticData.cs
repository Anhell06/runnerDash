using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Assets.CodeBase.Servises.StaticDataService
{
    public class TileStaticData
    {
        public Dictionary<string, TileBase> ViewTiles;
        public Dictionary<string, TileBase> ColisionTiles;
        public Dictionary<string, TileBase> ItemTiles;

        public void LoadAllTiles()
        {
            LoadViewTiles();
            LoadColisionTiles();
            LoadItemTiles();
        }

        private void LoadViewTiles() => ViewTiles = LoadAll("BattleField/TileMap/ViewPalette/Tile");
        private void LoadColisionTiles() => ColisionTiles = LoadAll("BattleField/TileMap/ColisionPalette/Tile");
        private void LoadItemTiles() => ItemTiles = LoadAll("BattleField/TileMap/ItemPalette/Tile");

        private Dictionary<string, TileBase> LoadAll(string inFolder) =>
            Resources.LoadAll<TileBase>(inFolder).ToDictionary(t => t.name);
    }
}
