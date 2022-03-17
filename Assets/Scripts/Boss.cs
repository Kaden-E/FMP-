using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{

    public float[] daggerSpeed = {2.5f, -2.5f};
    public float distance = 0.25f;
    public Transform[] daggers;





    private void Update(){

        for (int i = 0; i < daggers.Length; i ++){
            daggers[i].position = transform.position + new Vector3(-Mathf.Cos(Time.time * daggerSpeed[i]) * distance, Mathf.Sin(Time.time * daggerSpeed[i]) * distance, 0);
        }
    
        
    }





}
