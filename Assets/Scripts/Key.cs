using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Collidable
{

    public bool PlayerHasBomb;


    protected override void OnCollide(Collider2D coll)
    {
        base.OnCollide(coll);
        PlayerHasBomb = true;
        Debug.Log("pickup");
        Destroy(gameObject);
    }






}
