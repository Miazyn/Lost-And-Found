using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class After_dog_mainstreet : MonoBehaviour
{

    cutscene_manager cutscene;

    [Header("Valerie")]
    public GameObject valerie_npc;
    public GameObject valerie_non_interact;
    public GameObject valerie_foodcard;

    [Header("Newspaper")]
    public GameObject newspaper;
    public GameObject newspaper_interact;

    [Header("Interactions Text")]
    public interactions_text hunger_starts;
    public interactions_text know_about_card;
    public interactions_text gave_food_card;

    [Header("Others")]
    public GameObject robinson, maria;
    public GameObject arrow_to_robinson;

    [Header("Scripts")]
    public ClickManager click;
    public UI_Controller ui;

    AudioSource audiosource;


    private void Start()
    {
        audiosource = gameObject.GetComponent<AudioSource>();
        cutscene = GameObject.Find("Cutscene_Manager(Clone)").GetComponent<cutscene_manager>();
        ////FINAL CUTSCENE RDY
        //if (cutscene.ate_time_for_final)
        //{
        //    Debug.Log("final");
        //    robinson.SetActive(false);
        //    maria.SetActive(false);
        //    valerie_non_interact.SetActive(false);

        //}
        if (cutscene.house_done && !cutscene.hunger_started)
        {
            Debug.Log("House done");
            //VALERIE:
            valerie_non_interact.SetActive(false);
            valerie_npc.SetActive(true);

            robinson.SetActive(false);
            maria.SetActive(false);

            //OBJECTS
            newspaper.SetActive(true);
            newspaper_interact.SetActive(false);

            //CAN PLAY HUNGRY

            audiosource.Play();
            click.current_text = hunger_starts;
            click.type_of_text = "npc";
            click.text_being_displayed = true;
            click.counter = 0;
            click.StartDialog();
            cutscene.hunger_started = true;
        }
        if(cutscene.house_done && cutscene.hunger_started)
        {
            Debug.Log("House done");
            //VALERIE:
            valerie_non_interact.SetActive(false);
            valerie_npc.SetActive(true);

            robinson.SetActive(false);
            maria.SetActive(false);

            //OBJECTS
            newspaper.SetActive(true);
            newspaper_interact.SetActive(false);

            //Know about card
            if (cutscene.know_card)
            {
                valerie_npc.SetActive(false);
                valerie_foodcard.SetActive(true);

                newspaper_interact.SetActive(true);
                arrow_to_robinson.SetActive(true);
                if (cutscene.gotNewspaper)
                {
                    newspaper.SetActive(false);
                    newspaper_interact.SetActive(false);
                }
            }
        }

    }
    private void Update()
    {
        //Dialogue knows about card.
        if (click.current_text == know_about_card)
        {
            //Get to robinson
            if (ui.interation_just_ended)
            {
                cutscene.know_card = true;
                newspaper_interact.SetActive(true);

                arrow_to_robinson.SetActive(true);

                valerie_npc.SetActive(false);
                valerie_foodcard.SetActive(true);

            }
        }

        //NEWSPAPER PICKUP
        if (cutscene.know_card && !cutscene.gotNewspaper)
        {
            if (!newspaper_interact.activeSelf)
            {
                newspaper.SetActive(false);
                cutscene.gotNewspaper = true;
            }
        }


        //Food card given owo
        if (click.current_text == gave_food_card)
        {
            if (ui.interation_just_ended)
            {
                cutscene.used_food_card = true;
                //Cutscene darkened
                valerie_foodcard.SetActive(false);
                valerie_non_interact.SetActive(true);
                cutscene.ate_time_for_final = true;
            }
        }

        if (cutscene.ate_time_for_final)
        {
            robinson.SetActive(false);
            maria.SetActive(false);
            valerie_foodcard.SetActive(false);
            newspaper.SetActive(false);
            newspaper_interact.SetActive(false);
            valerie_non_interact.SetActive(false);

            arrow_to_robinson.SetActive(false);
        }
    }



}
