using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Random = UnityEngine.Random;

public class SImpleRandomWalkMapGen : AbstractDungeonGen
{

    [SerializeField]
    private SimpleRandomWalkSO randomWalkParam;

    protected override void RunRandomGen()
    {
        HashSet<Vector2Int> FloorPos = RunRandomWalk(randomWalkParam);
        tilemapVisualiser.Clear();
        tilemapVisualiser.PaintFloorTiles(FloorPos);
        WallGen.CreateWalls(FloorPos, tilemapVisualiser);
    }

    protected HashSet<Vector2Int> RunRandomWalk(SimpleRandomWalkSO parameters)
    {
        var currentPos = startPos;
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
