using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutscene_manager : MonoBehaviour
{
    #region[VarDeclaration]
    [Header("Bunker Start Scene 1 Working")]
    public bool bunker_wake_up_done;
    public bool main_street_lady_done;

    [Header("House Cutscene 2 Working")]
    public bool lucky_interacted;
    public bool key_available;
    //Keys gotten
    public bool key_gotten;
    public bool key_used;
    //Bear gotten & Dog
    public bool bear_inspected;
    public bool bear_gotten;
    public bool gotdog;
    public bool house_done;

    [Header("Hungry boi")]
    public bool hunger_started;
    public bool know_card;

    [Header("Newspaper related")]
    public bool gotNewspaper;
    public bool used_newspaper;

    [Header("Food card")]
    public bool got_food_card;
    public bool used_food_card;

    [Header("Finale")]
    public bool ate_time_for_final;

    

    public bool loadedLeft = false;
    #endregion
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

}
