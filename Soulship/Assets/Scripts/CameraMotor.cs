using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    public Transform lookAt;
    public float boundX = 0.3f;
    public float BoundY = 0.15f;

    private void LateUpdate() 
    {
        Vector3 delta = Vector3.zero;
        //bounds check for the x
        float deltaX = lookAt.position.x - transform.position.x;
        if(deltaX > boundX || deltaX < -boundX )
        {
            if(transform.position.x < lookAt.position.x)
            {
                delta.x = deltaX - boundX;
            }
            else
            {
                delta.x = deltaX + boundX;
            }
        }

        //bounds check for the Y
        float deltaY = lookAt.position.y - transform.position.y;
        if(deltaY > BoundY || deltaY < -BoundY )
        {
            if(transform.position.x < lookAt.position.x)
            {
                delta.y = deltaY - BoundY;
            }
            else
            {
                delta.y = deltaY + BoundY; 
            }
        }

        transform.position += new Vector3(delta.x, delta.y, 0);   
    }


}
