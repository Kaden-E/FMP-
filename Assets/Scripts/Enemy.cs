using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Mover
{
    //XP

    public int XpValue = 1;

    //Logic
    public float triggerLenght = 1.0f;
    public float chaseLenght = 5.0f;
    private bool chasing;
    private bool collidingWithPlayer;
    private Transform playerTransform;
    private Vector3 startingPos;


    //HitBox
    public ContactFilter2D filter;
    private BoxCollider2D hitBox;
    private Collider2D[] hits = new Collider2D[10];

    protected override void start()
    {
        base.start();
        playerTransform = GameManager.instance.player.transform;
        startingPos = transform.position;
        hitBox = transform.GetChild(0).GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        if(Vector3.Distance(playerTransform.position, startingPos) < chaseLenght)
        {
            if (Vector3.Distance(playerTransform.position, startingPos) < triggerLenght)
            {
                chasing = true;
                if(chasing){
                    if(!collidingWithPlayer)
                
                    UpdateMotor((playerTransform.position - transform.position).normalized);
                }   
            }
            
            else
            {
                UpdateMotor(startingPos - transform.position);
            }
        }
        else
        {
            UpdateMotor(startingPos - transform.position);
            chasing = false;

        }

        //Check for overlaps
        collidingWithPlayer = false;
        boxCollider.OverlapCollider(filter,hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if(hits[i] == null){
                continue;
            }

            if(hits[i].tag =="Fighter" && hits[i].name == "Player"){
                collidingWithPlayer = true;
            }

            hits[i] = null;

        }

    }

    protected override void Death()
    {
        Destroy(gameObject);
        GameManager.instance.XP += XpValue;
        GameManager.instance.ShowText("+" + XpValue + " xp", 30,  Color.magenta, transform.position, Vector3.up * 40, 1.0f );
    }



}