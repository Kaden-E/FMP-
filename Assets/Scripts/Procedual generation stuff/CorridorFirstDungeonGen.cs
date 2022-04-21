using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class CorridorFirstDungeonGen : SImpleRandomWalkMapGen
{
    [SerializeField]
    private int corridorLength = 14, corridorCount = 5;
    [SerializeField]
    [Range(0.1f, 1)]
    public float roomPercent = 0.8f;

    protected override void RunRandomGen()
    {
        CorridorFirstGeneration();
    }

    private void CorridorFirstGeneration()
    {
        HashSet<Vector2Int> floorPositions = new HashSet<Vector2Int>();
        HashSet<Vector2Int> PotentialRoomPos = new HashSet<Vector2Int>();

        CreateCorridors(floorPositions, PotentialRoomPos);

        HashSet<Vector2Int> roomPos = CreateRoom(PotentialRoomPos);

        floorPositions.UnionWith(roomPos);

        tilemapVisualiser.PaintFloorTiles(floorPositions);
        WallGen.CreateWalls(floorPositions, tilemapVisualiser);
    }

    private HashSet<Vector2Int> CreateRoom(HashSet<Vector2Int> potentialRoomPos)
    {
        HashSet<Vector2Int> roomPos = new HashSet<Vector2Int>();
        int roomToCreateCount = Mathf.RoundToInt (potentialRoomPos.Count * roomPercent);

        List<Vector2Int> RoomToCreate = potentialRoomPos.OrderBy(x => Guid.NewGuid()).Take(roomToCreateCount).ToList();

        foreach (var vector2Int in RoomToCreate)
        {
            var roomFloor = RunRandomWalk(randomWalkParam, vector2Int);
            roomPos.UnionWith(roomFloor);
        }
        return roomPos;


    }

    private void CreateCorridors(HashSet<Vector2Int> floorPositions, HashSet<Vector2Int> PotentialRoomPos)
    {
        var currentPos = startPos;
        PotentialRoomPos.Add(currentPos);

        for (int i = 0; i < corridorCount; i++)
        {
            var corridor = RandomDungeon.RandomWalkCorridor(currentPos, corridorLength);
            currentPos = corridor[corridor.Count - 1];
            PotentialRoomPos.Add(currentPos);
            floorPositions.UnionWith(corridor);
        }
    }
}
