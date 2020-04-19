using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class About : MonoBehaviour
{
    public string MenuScene;
    
    public void BackToMenu()
    {
        SceneManager.LoadScene(MenuScene);
    }    
}
