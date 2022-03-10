using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake() {

        if(GameManager.instance !=null){
            Destroy(gameObject);
            return;
        }

        instance = this;
        SceneManager.sceneLoaded+= LoadState;
        DontDestroyOnLoad(gameObject);
        //This function resets progress.
        //PlayerPrefs.DeleteAll();
    }
    

    //Resources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    //Refrences
    public Player player;
    public Weapon weapon;
    public FloatingTextManager floatingTextManager;

    //logic 
    public int gold;
    public int XP;

    public void ShowText(string msg, int fontSize, Color colour, Vector3 position, Vector3 motion, float duration){
        floatingTextManager.show(msg, fontSize, colour, position, motion, duration);
    }


    //save states
    /*
    * INT Skin
    * INT Gold
    * INT XP
    * INT WeaponLvl
    */

    //Upgrade weapon
    public bool TryUpgradeWeapon(){
        //is the weapon maxed?
        if(weaponPrices.Count <= weapon.WeaponLvl){
            return false;
        }

        if(gold >= weaponPrices[weapon.WeaponLvl]){
            gold -= weaponPrices[weapon.WeaponLvl];
            weapon.UpgradeWeapon();
            return true;
        }

        return false;
    }





    public void savedState(){
        Debug.Log("Save state");
        string s ="";
        s += "0" + "|";
        s += gold.ToString() + "|";
        s += XP.ToString() + "|";
        s += weapon.WeaponLvl.ToString();

        PlayerPrefs.SetString("SaveState", s);
    }
    
    public void LoadState(Scene s,LoadSceneMode mode){

        if (!PlayerPrefs.HasKey("SaveState")){
            return;
        }

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');
        
        //Change Player skin
        gold = int.Parse(data[1]);
        XP = int.Parse(data[2]);
        //Change Weapon LVL
        weapon.SetWeaponLvl(int.Parse(data[3]));



        Debug.Log("Load State");
    }


}
