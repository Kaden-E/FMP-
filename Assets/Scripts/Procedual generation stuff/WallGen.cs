using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WallGen
{
    public static void CreateWalls(HashSet<Vector2Int> floorPositions, TilemapVisualiser tilemapVisualiser)
    {
        var basicWallPos = FindWallsInDir(floorPositions, Direction2D.cardinalDirList);
        foreach (var position in basicWallPos)
        {
            tilemapVisualiser.PaintSingleBasicWall(position);
        }
    }

    private static HashSet<Vector2Int> FindWallsInDir(HashSet<Vector2Int> floorPositions, List<Vector2Int> dirList)
    {
        HashSet<Vector2Int> wallPositions = new HashSet<Vector2Int>();
        foreach (var position in floorPositions)
        {
            foreach (var direction in dirList)
            {
                var neighbourPos = position + direction;
                if (floorPositions.Contains(neighbourPos) == false)
                {
                    wallPositions.Add(neighbourPos);
                }
            }
        }
        return wallPositions;
    }



}
