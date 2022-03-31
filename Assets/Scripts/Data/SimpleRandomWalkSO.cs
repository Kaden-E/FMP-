using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "SimpleRandomWalkParam_", menuName = "PCG/Simple")]

public class SimpleRandomWalkSO : ScriptableObject
{

    public int iterations = 10, walkLength = 10;
    public bool StartRandomEachIteration = true;




}
