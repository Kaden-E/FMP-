using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : Collidable
{
    public Key key;
    public bool DoorOpen;

    protected override void OnCollide(Collider2D coll)
    {
        base.OnCollide(coll);
        if (key.PlayerHasBomb)
        {
            Debug.Log("unlock");
            Destroy(gameObject);
            key.PlayerHasBomb = false;
        }
        else
            Debug.Log("No way through");
    }




}
