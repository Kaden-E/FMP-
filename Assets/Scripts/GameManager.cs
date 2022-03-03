using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake() {
        instance = this;
        SceneManager.sceneLoaded+= savedState;
        SceneManager.sceneLoaded+= LoadState;
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
    public void savedState(Scene s,LoadSceneMode mode){
        Debug.Log("Save state");

    }
    
    public void LoadState(Scene s,LoadSceneMode mode){
        Debug.Log("Load State");
    }


}
