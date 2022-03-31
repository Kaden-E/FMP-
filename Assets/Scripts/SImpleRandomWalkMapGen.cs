using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Random = UnityEngine.Random;

public class SImpleRandomWalkMapGen : MonoBehaviour
{
    [SerializeField]
    protected Vector2Int startPos = Vector2Int.zero;

    [SerializeField]
    private int iterations = 10;

    [SerializeField]
    public int walkLength = 10;

    [SerializeField]
    public bool StartRandom = true;

    [SerializeField]
    private TilemapVisualiser tilemapVisualiser;




    public void RunProceduralGen()
    {
        HashSet<Vector2Int> FloorPos = RunRandomWalk();
        tilemapVisualiser.Clear();
        tilemapVisualiser.PaintFloorTiles(FloorPos);
    }

    protected HashSet<Vector2Int> RunRandomWalk()
    {
        var currentPos = startPos;
        HashSet<Vector2Int> FloorPos = new HashSet<Vector2Int>();
        for (int i = 0; i < iterations; i++)
        {
            var path = RandomDungeon.SimpleRandomWalk(currentPos, walkLength);
            FloorPos.UnionWith(path);
            if (StartRandom)
            {
                currentPos = FloorPos.ElementAt(Random.Range(0, FloorPos.Count));
            }
        }
        return FloorPos;
    }







}
