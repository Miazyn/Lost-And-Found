using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class general_cutscene_house : MonoBehaviour
{
    cutscene_manager cutscene;

    public GameObject key_pickup_object;
    public GameObject inspect_pockets_for_key;
    public GameObject inspect_sleeper;

    //DOG
    public GameObject inspect_lucky;
    public GameObject key_check_lucky;

    public interactions_text text_lucky_inspection;
    public interactions_text text_inspect_pocket;

    public interactions_text text_opened_lock_freedLucky;
    
    public ClickManager click;
    public UI_Controller ui;

    public Transform lucky_on_child;
    public GameObject player;

    private void Start()
    {
        cutscene = GameObject.Find("Cutscene_Manager(Clone)").GetComponent<cutscene_manager>();

        //LUCKY LOOKED AT
        if (cutscene.lucky_interacted && !cutscene.key_available)
        {
            inspect_sleeper.SetActive(false);
            inspect_pockets_for_key.SetActive(true);
            inspect_lucky.SetActive(false);
            key_check_lucky.SetActive(true);
        }

        //KEY AVAILABLE
        if (cutscene.key_available && !cutscene.key_gotten)
        {
            inspect_sleeper.SetActive(false);
            inspect_pockets_for_key.SetActive(false);
            key_pickup_object.SetActive(true);
            inspect_lucky.SetActive(false);
            key_check_lucky.SetActive(true);
        }

        //GOT KEY ALRDY
        if (cutscene.key_gotten && !cutscene.key_used)
        {
            key_pickup_object.SetActive(false);
            inspect_pockets_for_key.SetActive(false);
            inspect_sleeper.SetActive(false);
            inspect_lucky.SetActive(false);
            key_check_lucky.SetActive(true);
        }

        //KEY USED & LUCKY
        if (cutscene.key_used && cutscene.gotdog)
        {
            inspect_lucky.SetActive(false);
            key_check_lucky.SetActive(false);
        }

        if (cutscene.house_done)
        {
            inspect_sleeper.SetActive(true);
        }

    }

    private void Update()
    {
        //INSPECTING LUCKY
        if (click.current_text == text_lucky_inspection)
        {
            cutscene.lucky_interacted = true;
            inspect_lucky.SetActive(false);
            key_check_lucky.SetActive(true);
            if (inspect_sleeper.activeSelf)
            {
                inspect_sleeper.SetActive(false);
            }
            if (!inspect_pockets_for_key.activeSelf)
            {
                inspect_pockets_for_key.SetActive(true);
            }
        }

        if (click.current_text == text_inspect_pocket)
        {
            if (inspect_pockets_for_key.activeSelf)
            {
                inspect_pockets_for_key.SetActive(false);
            }
            if (ui.interation_just_ended)
            {
                key_pickup_object.SetActive(true);
                cutscene.key_available = true;
            }
            
            
        }

        if (cutscene.key_available && !cutscene.key_gotten)
        {
            if (!key_pickup_object.activeSelf)
            {
                cutscene.key_gotten = true;
            }
        }

        if (click.current_text == text_opened_lock_freedLucky)
        {
            cutscene.key_used = true;
            //Make Him Walk to you
            cutscene.gotdog = true;
            key_check_lucky.SetActive(false);
            player.transform.GetChild(1).gameObject.SetActive(true);
        }

        if (cutscene.gotdog && cutscene.bear_gotten)
        {
            cutscene.house_done= true;
        }


    }
}
