using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class TileMapVisualizer : MonoBehaviour
{
    [SerializeField]
    private Tilemap Floortiles;
    [SerializeField]
    private TileBase floorTile;
    public void paintingFloor(IEnumerable<Vector2Int> floorPosition)  
    {
        paintTile(floorPosition, Floortiles, floorTile); 
    }

    private void paintTile(IEnumerable<Vector2Int> floorPosition, Tilemap tileMaap, TileBase tile)
    {
        foreach (var position in floorPosition)
        {
            PaintSingleTile(tileMaap, tile, position);
        }
    }

    private void PaintSingleTile(Tilemap tileMaap, TileBase tile, Vector2Int position)
    {
        var tilePosition = tileMaap.WorldToCell((Vector3Int)position);
        tileMaap.SetTile(tilePosition,tile);
    }
    public void ClearTiles()
    {
        Floortiles.ClearAllTiles();
    }
}
