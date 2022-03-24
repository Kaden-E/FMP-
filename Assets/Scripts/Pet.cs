using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet : Collidable
{

    //Damage struct
    public int[] damagePoint = { 4, 8 };
    public float[] pushForce = { 1.5f, 3.0f };

    //Upgrades
    public int PetLvl = 0;
    public SpriteRenderer spriteRenderer;

    public void UpgradePet()
    {
        PetLvl++;
        spriteRenderer.sprite = GameManager.instance.petSprites[PetLvl];
        Debug.Log("upgarde");

    }


}
