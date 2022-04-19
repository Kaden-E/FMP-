using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class Boss_music : Collidable
{
    public AudioSource audioData;

    protected override void OnCollide(Collider2D coll)
    {
        audioData.Play(0);
        base.OnCollide(coll);

    }




}
