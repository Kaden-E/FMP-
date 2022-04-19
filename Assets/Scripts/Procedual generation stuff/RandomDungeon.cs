using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RandomDungeon
{
    public static HashSet<Vector2Int> SimpleRandomWalk(Vector2Int startPos, int walkLen)
    {
        HashSet<Vector2Int> path = new HashSet<Vector2Int>();

        path.Add(startPos);
        var prevPos = startPos;

        for (int i = 0; i < walkLen; i++)
        {
            var newPos = prevPos + Direction2D.GetRandomCardinalDir();
            path.Add(newPos);
            prevPos = newPos;
        }
        return path;
    }

    public static List<Vector2Int> RandomWalkCorridor(Vector2Int startPosition, int corridorLength)
    {
        List<Vector2Int> corridor = new List<Vector2Int>();
        var direction = Direction2D.GetRandomCardinalDir();
        var currentPosition = startPosition;
        corridor.Add(currentPosition);

        for (int i = 0; i < corridorLength; i++)
        {
            currentPosition += direction;
            corridor.Add(currentPosition);
        }
        return corridor;
    }
}

public static class Direction2D
{
    public static List<Vector2Int> cardinalDirList = new List<Vector2Int>
    {
        new Vector2Int(0, 1), //UP
        new Vector2Int(1, 0), //RIGHT
        new Vector2Int(0, -1), //DOWN
        new Vector2Int(-1, 0), //LEFT
    };

    public static Vector2Int GetRandomCardinalDir()
    {
        return cardinalDirList[Random.Range(0, cardinalDirList.Count)];
    }
}




