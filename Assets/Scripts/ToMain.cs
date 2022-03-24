using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMain : Collidable
{
    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player")
        {
            //teleport the player
            GameManager.instance.savedState();
            SceneManager.LoadScene(4);
        }
    }
}
