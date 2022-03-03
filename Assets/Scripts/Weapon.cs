using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collidable
{
    // Damage struct

    
    public int damagePoint = 1;
    public float pushForce = 2.0f;

    //Upgrades
    public int WeaponLvl = 0;
    private SpriteRenderer spriteRenderer;

    //swing
    private float cooldown = 0.5f;
    private float lastSwing;


    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    protected override void Update()

    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.Space)){
            if (Time.time - lastSwing > cooldown){
                lastSwing = Time.time;
                Swing();
            }
        }
    }

    protected override void OnCollide(Collider2D coll){

        if(coll.tag == "Fighter"){
            

            if(coll.name == "Player"){
                
                return;
            }
            Damage dmg = new Damage{
                dmgAmount = damagePoint,
                origin = transform.position,
                pushForce = pushForce
            };
            coll.SendMessage("ReciveDamage", dmg);
            Debug.Log(coll.name);

            
        }

  
    }


    private void Swing(){
        Debug.Log("Swing");
    }






}

