using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneMovers : MonoBehaviour
{
    public void ToOptions()
    {
        SceneManager.LoadScene(4);
    }

    public void ToMain()
    {
        SceneManager.LoadScene(3);
    }

    public void ToGame()
    {
        SceneManager.LoadScene(0);
    }
}
