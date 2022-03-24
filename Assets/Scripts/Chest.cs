using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Chest : Collectable
{
    public Sprite emptyChest;
    public int goldAmount = 5;
    public AudioSource AudioData;


    protected override void OnCollect()
    {

        if (!collected)
        {
            collected = true;
            AudioData.Play(0);
            GetComponent<SpriteRenderer>().sprite = emptyChest;
            GameManager.instance.gold += goldAmount;
            GameManager.instance.ShowText("+" + goldAmount + " Gold!", 25, Color.yellow, transform.position, Vector3.up * 25, 1.5f);
        }





    }




}
