using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterMenu : MonoBehaviour
{

    // Text
    public Text levelText, hitpointText, goldText, upgradeText, xpText;
    
    //Logic
    private int currentcharSelection;
    public Image charSelectionSprite;
    public Image weaponSprite;
    public RectTransform xpBar;


    // Char selction
    public void OnArrowClick(bool right){
        if(right){
            currentcharSelection++;
            if (currentcharSelection == GameManager.instance.playerSprites.Count){
                currentcharSelection = 0;
            }
            OnSelectionChange(); 
        }

        else{
            currentcharSelection--;
            if (currentcharSelection < 0 ){
                currentcharSelection = GameManager.instance.playerSprites.Count - 1;
            }
            OnSelectionChange(); 
        }
    }

    private void OnSelectionChange(){
        charSelectionSprite.sprite = GameManager.instance.playerSprites[currentcharSelection];
    }

    //Weapon upgrade

    public void OnUpgradeClick(){
        if(GameManager.instance.TryUpgradeWeapon()){
            UpdateMenu();
        }
    }

    //Update the char info
    public void UpdateMenu(){

        //Weapon

        weaponSprite.sprite = GameManager.instance.weaponSprites[GameManager.instance.weapon.WeaponLvl];
        if(GameManager.instance.weapon.WeaponLvl == GameManager.instance.weaponPrices.Count){
            upgradeText.text = "MAX";
        }
        else
            upgradeText.text = GameManager.instance.weaponPrices[GameManager.instance.weapon.WeaponLvl].ToString();

        //meta

        hitpointText.text = GameManager.instance.player.hitPoint.ToString();
        goldText.text = GameManager.instance.gold.ToString();
        levelText.text = "NOT IMPLEMENTED";

        //XP bar
        xpText.text = "NOT IMPLMEENTED";
        xpBar.localScale = new Vector3(0.5f, 0, 0);

    }




}
