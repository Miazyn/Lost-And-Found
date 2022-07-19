using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuManager : MonoBehaviour
{
    
    public void StartGame()
    {
        SceneManager.LoadScene("Start_Cutscene", LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
