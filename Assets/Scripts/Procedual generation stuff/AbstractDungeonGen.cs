using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractDungeonGen : MonoBehaviour
{

    [SerializeField]
    protected TilemapVisualiser tilemapVisualiser = null;

    [SerializeField]
    protected Vector2Int startPos = Vector2Int.zero;

    public void GenDungeon()
    {
        tilemapVisualiser.Clear();
        RunRandomGen();
    }


    protected abstract void RunRandomGen();






}
