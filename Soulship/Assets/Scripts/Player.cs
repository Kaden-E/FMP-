using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollider;

    private Vector3 moveDelta;

    private void start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        //Reset the moveDelta
        moveDelta = new Vector3(x,y,0); 

        //Swap sprite direction, whether your going right or left.
        if(moveDelta.x > 0)
        {
            transform.localScale = Vector3.one;
        }
        else if (moveDelta.x < 0){
            transform.localScale = new Vector3 (-1,1,0); 
        }

        // movement 
        transform.Translate(moveDelta * Time.deltaTime);
        

    }



}
