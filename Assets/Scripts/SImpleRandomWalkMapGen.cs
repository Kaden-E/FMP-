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
        HashSet<Vector2Int> FloorPos = RunRandomWalk();
        tilemapVisualiser.Clear();
        tilemapVisualiser.PaintFloorTiles(FloorPos);
    }

    protected HashSet<Vector2Int> RunRandomWalk()
    {
        var currentPos = startPos;
        HashSet<Vector2Int> FloorPos = new HashSet<Vector2Int>();
        for (int i = 0; i < randomWalkParam.iterations; i++)
        {
            var path = RandomDungeon.SimpleRandomWalk(currentPos, randomWalkParam.walkLength);
            FloorPos.UnionWith(path);
            if (randomWalkParam.StartRandomEachIteration)
            {
                currentPos = FloorPos.ElementAt(Random.Range(0, FloorPos.Count));
            }
        }
        return FloorPos;
    }

}
