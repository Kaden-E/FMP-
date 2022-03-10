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
        GameManager.instance.player.SwapSprite(currentcharSelection);
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
        levelText.text = GameManager.instance.GetCurrentLvl().ToString();

        //XP bar
        int currLvl = GameManager.instance.GetCurrentLvl();
        if( currLvl == GameManager.instance.xpTable.Count){
            xpText.text = GameManager.instance.XP.ToString() + " total xp points"; //display total xp if max lvl
            xpBar.localScale = Vector3.one;
        }
        else{
            int prevLvlXp = GameManager.instance.GetXpToLevel(currLvl -1);
            int currLvlXp = GameManager.instance.GetXpToLevel(currLvl);

            int diff = currLvlXp - prevLvlXp;
            int currXpIntoLvl = GameManager.instance.XP - prevLvlXp;

            float comletionRatio = (float)currXpIntoLvl / (float)diff;
            xpBar.localScale = new Vector3(comletionRatio, 1, 1);
            xpText.text = currXpIntoLvl.ToString() + " / " + diff;
        }

    }




}
