using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class wallgeneration 
{
  public static void wallCreation(HashSet<Vector2Int> floorPositions,TileMapVisualizer tilemapping)
    {
        var wallPos = FindwallsDirections(floorPositions, NewDirection2D.DirectionalList);
        foreach (var position in wallPos)
        {
            tilemapping.PaintWall(position);
        }
    }

    private static HashSet<Vector2Int> FindwallsDirections(HashSet<Vector2Int> floorPositions, List<Vector2Int> directions)
    {
        HashSet<Vector2Int> wallPosition = new HashSet<Vector2Int>();
        foreach (var position in floorPositions)
        {
            foreach (var direction in directions)
            {
                var neighbouringPosition = position + direction;
                if (floorPositions.Contains(neighbouringPosition)==false)
                {
                    wallPosition.Add(neighbouringPosition);
                }
            }
        }
        return wallPosition;
    }
}
