using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{    
    public string GameScene;
    public string AboutScene;

    public void StartGame()
    {
        SceneManager.LoadScene(GameScene);
    }

    public void ShowAbout()
    {
        SceneManager.LoadScene(AboutScene);
    }    
}
