using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneMovers : MonoBehaviour
{
    public void ToOptions()
    {
        SceneManager.LoadScene(2);
    }

    public void ToMain()
    {
        SceneManager.LoadScene(0);
    }

    public void ToGame()
    {
        SceneManager.LoadScene(3);
    }


}
