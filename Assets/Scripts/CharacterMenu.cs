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

    }

}
