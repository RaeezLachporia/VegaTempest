using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Random = UnityEngine.Random;

public class PathwayMapGen : MonoBehaviour
{
    [SerializeField]
    protected Vector2Int startingPosstion = Vector2Int.zero;
    [SerializeField]
    private int Iterations = 10;
    [SerializeField]
    public int walkingLength = 10;
    [SerializeField]
    public bool startIterations = true;
    [SerializeField]
    private TileMapVisualizer tileMapVisualizer;
    public void runGeneration()
    {
        HashSet<Vector2Int> floorPositions = runRandomWalk();
        foreach (var position in floorPositions)
        {
            Debug.Log(position);
        }
        tileMapVisualizer.ClearTiles();
        tileMapVisualizer.paintingFloor(floorPositions);
        
    }

    protected HashSet<Vector2Int> runRandomWalk()
    {
        var currentPosition = startingPosstion;
        HashSet<Vector2Int> floorPositions = new HashSet<Vector2Int>();
        for (int i = 0; i < Iterations; i++)
        {
            var path = GenerationAlgorithm.RandomWalk(currentPosition, walkingLength);
            floorPositions.UnionWith(path);
            if (startIterations)
            {
                currentPosition = floorPositions.ElementAt(Random.Range(0, floorPositions.Count));
            }
            
        }
        return floorPositions;
    }
}
