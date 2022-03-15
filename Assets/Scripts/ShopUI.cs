using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : Collidable
{
    Animator anim;

    void start(){
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.CompareTag("Fighter")){
            Debug.Log("hfhfhfh");
            anim.Play("Shop_Showing");
        }
    }

    


}
