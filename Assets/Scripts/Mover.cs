using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : Fighter
{

    public BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private RaycastHit2D hit;
    
    protected float yspeed = 0.75f;
    protected float xspeed = 1.0f;

    protected virtual void Start(){
        boxCollider = GetComponent<BoxCollider2D>();
    }


    protected virtual void UpdateMotor (Vector3 input){
        //Reset the moveDelta
        moveDelta = new Vector3(input.x * xspeed, input.y * yspeed, 0);

        //Swap sprite direction, whether your going right or left.
        if(moveDelta.x > 0)
        {
            transform.localScale = Vector3.one;
        }
        else if (moveDelta.x < 0){
            transform.localScale = new Vector3 (-1,1,1); 
        }
        //Movement clarification
       hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider ==null){
        // movement 
        transform.Translate(0,moveDelta.y * Time.deltaTime,0);

        }
        //Movement clarification
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider ==null){
        // movement 
        transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }
    }
}
