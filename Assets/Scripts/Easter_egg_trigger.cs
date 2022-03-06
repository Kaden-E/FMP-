using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Easter_egg_trigger : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D col){
        Debug.Log("Easter egg unlocked");
    }
}
