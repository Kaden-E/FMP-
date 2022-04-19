using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitBox : Collidable
{   
    public int damage = 1;
    public int pushForce = 5;

    protected override void OnCollide(Collider2D coll){
        if(coll.tag == "Fighter" && coll.name == "Player"){
            Damage dmg = new Damage{
                dmgAmount = damage,
                origin = transform.position,
                pushForce = pushForce
            };
            coll.SendMessage("ReciveDamage", dmg);
            Debug.Log(coll.name);
        }
    }
    



}
