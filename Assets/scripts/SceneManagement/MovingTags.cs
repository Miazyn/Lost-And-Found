using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovingTags : MonoBehaviour
{
    //CheckDirection(), CheckPos(), loadingFromLeft/Right(), playerRef

    public player_movement player_reference;
    Scene currentScene;
    //Below all Scenes to be used:
    string bunker = "Scene_1_bunker";
    string main_street = "Scene_2_mainstreet";
    string house = "Scene_3_house";
    string bar = "Scene_4_robinson";

    public string prev_scene;

    private void Start()
    {
        
    }

    private void Update()
    {
        
        
    }

    public void robinsonLoad()
    {
        currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == main_street)
        {
            SceneManager.LoadScene(bar, LoadSceneMode.Single);
        }
        if(currentScene.name == bar)
        {
            SceneManager.LoadScene(main_street, LoadSceneMode.Single);
        }
    }

    public void loadingFinalLeft()
    {
        SceneManager.LoadScene("Ending_All_Die", LoadSceneMode.Single);
    }

    public void loadingFinalRight()
    {
        SceneManager.LoadScene("Ending_Survive", LoadSceneMode.Single);
    }

    public void loadingLeftScene()
    {

        currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == bunker)
        {
            SceneManager.LoadScene(main_street, LoadSceneMode.Single);
        }
        if (currentScene.name == main_street)
        {
            SceneManager.LoadScene(house, LoadSceneMode.Single);
        }
    }
    public void loadingRightScene()
    {
        currentScene = SceneManager.GetActiveScene();
        Debug.Log(currentScene.name);
        if (currentScene.name == main_street)
        {
            
            SceneManager.LoadScene(bunker, LoadSceneMode.Single);
        }

        if (currentScene.name == house)
        {
            SceneManager.LoadScene(main_street, LoadSceneMode.Single);
        }
    }
}
