using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    public int hitPoint;
    public int maxHitpoint;
    public float pushRecoverySpeed = 0.2f;

    //Immunity
    protected float ImmuneTime = 1.0f;
    protected float lastImmune;

    //push
    protected Vector3 pushDirection;

    //All fighters damagable

    protected virtual void ReciveDamage(Damage dmg){
    if(Time.time - lastImmune > ImmuneTime){
        lastImmune = Time.time;
        hitPoint -= dmg.dmgAmount;
        pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;

        GameManager.instance.ShowText(dmg.dmgAmount.ToString(), 15, Color.red, transform.position,Vector3.zero, 0.5f);
        

        if(hitPoint <= 0){
            hitPoint = 0;
            Death();
        }
    }

    }

    protected virtual void Death(){

    }



}
