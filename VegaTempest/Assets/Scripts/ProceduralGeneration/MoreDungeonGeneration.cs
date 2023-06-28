using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MoreDungeonGeneration : MonoBehaviour
{
    [SerializeField] protected TileMapVisualizer tilemapvisualizer = null;
    [SerializeField] protected Vector2Int startPosition = Vector2Int.zero;
    public void generateDungeon()
    {
        tilemapvisualizer.ClearTiles();
        RunProceduralGenerating();
    }

    protected abstract void RunProceduralGenerating();
}
