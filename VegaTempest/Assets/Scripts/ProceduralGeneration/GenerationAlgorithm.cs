using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GenerationAlgorithm 
{
    public static HashSet<Vector2Int> RandomWalk(Vector2Int startingPosition, int walkingLength)
    {
        HashSet<Vector2Int> pathway = new HashSet<Vector2Int>();
        pathway.Add(startingPosition);
        var previousPosition = startingPosition;

        for (int i = 0; i < walkingLength; i++)
        {
            var newPosition = previousPosition + NewDirection2D.getDirectionalList();
            pathway.Add(newPosition);
            previousPosition = newPosition;
        }
        return pathway;
    }
}
 public static class NewDirection2D
{
    public static List<Vector2Int> DirectionalList = new List<Vector2Int>
    {
        new Vector2Int(0,1),//up
        new Vector2Int(1,0),//right
        new Vector2Int(0,-1),//down
        new Vector2Int(-1,0)//left
    };
    public static Vector2Int getDirectionalList()
    {
        return DirectionalList[Random.Range(0, DirectionalList.Count)];
    }
}