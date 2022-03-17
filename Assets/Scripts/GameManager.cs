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
            Destroy(player.gameObject);
            Destroy(floatingTextManager.gameObject);
            Destroy(HUD);
            Destroy(menu);
            return;
        }

        instance = this;
        SceneManager.sceneLoaded+= LoadState;
        SceneManager.sceneLoaded += OnSceneLoaded;
        //This function resets progress.
        //PlayerPrefs.DeleteAll();
    }
    
    #region Vars
    //Resources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    //Refrences
    public Player player;
    public Weapon weapon;
    public FloatingTextManager floatingTextManager;
    public RectTransform hitPointBar;
    public GameObject HUD;
    public GameObject menu;

    //logic 
    public int gold;
    public int XP;
    #endregion
    public void ShowText(string msg, int fontSize, Color colour, Vector3 position, Vector3 motion, float duration){
        floatingTextManager.show(msg, fontSize, colour, position, motion, duration);
    }




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

    public void OnSceneLoaded(Scene s, LoadSceneMode mode){
        player.transform.position = GameObject.Find("Spawnpoint").transform.position;
    }

    public int GetCurrentLvl(){
        int r = 0;
        int add = 0;

        while (XP >= add){
            add += xpTable[r];
            r++;

            if( r == xpTable.Count){ //Max lvl
                return r;
            }
        }
        return r;
    }

    public int GetXpToLevel(int level){
        int r = 0;
        int xp = 0;

        while (r < level){
            xp += xpTable[r];
            r++;
        }
        return xp;
    }

    public void GrantXp(int xp){
        int currLvl = GetCurrentLvl();
        XP += xp;
        if(currLvl < GetCurrentLvl()){
            OnLevelUp();
        }
    }

    public void OnLevelUp(){
        Debug.Log("Level Up!");
        player.OnLevelUp();
        OnHitPointChange();
    }

    public void savedState(){
        
        string s ="";
        s += "0" + "|";
        s += gold.ToString() + "|";
        s += XP.ToString() + "|";
        s += weapon.WeaponLvl.ToString();

        PlayerPrefs.SetString("SaveState", s);
    }

    public void LoadState(Scene s,LoadSceneMode mode){
        SceneManager.sceneLoaded -= LoadState;

        if (!PlayerPrefs.HasKey("SaveState")){
            return;
        }

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');
        
        //Change Player skin
        gold = int.Parse(data[1]);
        XP = int.Parse(data[2]);
        if(GetCurrentLvl() != 1){
            player.SetLevel(GetCurrentLvl());
        }
        
        //Change Weapon LVL
        weapon.SetWeaponLvl(int.Parse(data[3]));

        
    }
    
    //hitpoint Bar
    public void OnHitPointChange(){
        float ratio = (float)player.hitPoint / (float)player.maxHitpoint;
        hitPointBar.localScale = new Vector3 (1, ratio, 1);

    }






}
