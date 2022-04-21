using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Random = UnityEngine.Random;

public class SImpleRandomWalkMapGen : AbstractDungeonGen
{

    [SerializeField]
    protected SimpleRandomWalkSO randomWalkParam;

    protected override void RunRandomGen()
    {
        HashSet<Vector2Int> FloorPos = RunRandomWalk(randomWalkParam, startPos);
        tilemapVisualiser.Clear();
        tilemapVisualiser.PaintFloorTiles(FloorPos);
        WallGen.CreateWalls(FloorPos, tilemapVisualiser);
    }

    protected HashSet<Vector2Int> RunRandomWalk(SimpleRandomWalkSO parameters, Vector2Int pos)
    {
        var currentPos = pos;
        HashSet<Vector2Int> FloorPos = new HashSet<Vector2Int>();
        for (int i = 0; i < parameters.iterations; i++)
        {
            var path = RandomDungeon.SimpleRandomWalk(currentPos, parameters.walkLength);
            FloorPos.UnionWith(path);
            if (parameters.StartRandomEachIteration)
            {
                currentPos = FloorPos.ElementAt(Random.Range(0, FloorPos.Count));
            }
        }
        return FloorPos;
    }

}
