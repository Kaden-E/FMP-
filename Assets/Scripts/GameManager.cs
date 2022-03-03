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
    }

    //Resources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    //Refrences
    public Player player;
    //public weapon weapon

    //logic 
    public int gold;
    public int XP;

    //save states
    /*
    * INT Skin
    * INT Gold
    * INT XP
    * INT WeaponLvl
    */
    public void savedState(){
        Debug.Log("Save state");
        string s ="";
        s += "0" + "|";
        s += gold.ToString() + "|";
        s += XP.ToString() + "|";
        s += "0";

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

        Debug.Log("Load State");
    }


}
