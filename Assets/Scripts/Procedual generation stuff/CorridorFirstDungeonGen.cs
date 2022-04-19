using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorridorFirstDungeonGen : SImpleRandomWalkMapGen
{
    [SerializeField]
    private int corridorLength = 14, corridorCount = 5;
    [SerializeField]
    [Range(0.1f, 1)]
    public float roomPercent = 0.8f;
    [SerializeField]
    public SimpleRandomWalkSO roomGenerationParam;
    protected override void RunRandomGen()
    {
        CorridorFirstGeneration();
    }

    private void CorridorFirstGeneration()
    {
        HashSet<Vector2Int> floorPositions = new HashSet<Vector2Int>();
        CreateCorridors(floorPositions);
        tilemapVisualiser.PaintFloorTiles(floorPositions);
        WallGen.CreateWalls(floorPositions, tilemapVisualiser);
    }

    private void CreateCorridors(HashSet<Vector2Int> floorPositions)
    {
        var currentPos = startPos;

        for (int i = 0; i < corridorCount; i++)
        {
            var corridor = RandomDungeon.RandomWalkCorridor(currentPos, corridorLength);
            currentPos = corridor[corridor.Count - 1];
            floorPositions.UnionWith(corridor);
        }
    }
}
