using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collidable
{
    // Damage struct


    public int[] damagePoint = { 1, 2, 3, 4, 5, 6 };
    public float[] pushForce = { 2.0f, 2.2f, 2.4f, 2.6f, 2.8f, 3.0f };

    //Upgrades
    public int WeaponLvl = 0;
    public SpriteRenderer spriteRenderer;

    //swing
    private Animator anim;
    private float cooldown = 0.5f;
    private float lastSwing;


    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }


    protected override void Update()

    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Time.timeScale == 1.0f)
            {
                if (Time.time - lastSwing > cooldown)
                {
                    lastSwing = Time.time;
                    Swing();
                }

            }

        }
    }

    protected override void OnCollide(Collider2D coll)
    {

        if (coll.tag == "Fighter")
        {


            if (coll.name == "Player")
            {

                return;
            }
            Damage dmg = new Damage
            {
                dmgAmount = damagePoint[WeaponLvl],
                origin = transform.position,
                pushForce = pushForce[WeaponLvl],
            };
            coll.SendMessage("ReciveDamage", dmg);
            Debug.Log(coll.name);


        }


    }


    private void Swing()
    {
        //Debug.Log("Swing");
        anim.SetTrigger("Swing");
    }

    public void UpgradeWeapon()
    {
        WeaponLvl++;
        spriteRenderer.sprite = GameManager.instance.weaponSprites[WeaponLvl];

    }

    public void SetWeaponLvl(int level)
    {
        WeaponLvl = level;
        spriteRenderer.sprite = GameManager.instance.weaponSprites[WeaponLvl];

    }




}

