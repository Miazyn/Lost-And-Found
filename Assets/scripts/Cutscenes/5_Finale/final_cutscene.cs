using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class final_cutscene : MonoBehaviour
{
    public ClickManager click;
    public UI_Controller ui;

    public GameObject dog;
    public Animator dog_animator;
    public Transform dog_pos;

    cutscene_manager cutscene;

    [Header("Valerie")]
    public GameObject valerie_npc;
    public GameObject valerie_non_interact;
    public GameObject valerie_foodcard;

    [Header("Others")]
    public GameObject robinson, maria;
    public GameObject arrow_to_robinson;

    [Header("Background")]
    public GameObject move_arrow, move_arrow_1, bandaid, blood;
    public GameObject newspaper, pickUp;

    public GameObject moveleft_cutscene, moveright_cutscene;

    public interactions_text lucky_where_to;
    bool lucky_text = false;

    
    private void Start()
    {
        cutscene = GameObject.Find("Cutscene_Manager(Clone)").GetComponent<cutscene_manager>();
        
    }

    private void Update()
    {
        if (cutscene.ate_time_for_final && !lucky_text)
        {
            Debug.Log("Time for the finally");
            //Everything set inactive
            robinson.SetActive(false);
            maria.SetActive(false);

            valerie_non_interact.SetActive(false);
            valerie_foodcard.SetActive(false);
            valerie_npc.SetActive(false);

            arrow_to_robinson.SetActive(false);
            move_arrow.SetActive(false);
            move_arrow_1.SetActive(false);

            bandaid.SetActive(false);
            blood.SetActive(false);
            newspaper.SetActive(false);
            pickUp.SetActive(false);

            moveleft_cutscene.SetActive(true);
            moveright_cutscene.SetActive(true);
            if (!lucky_text && ui.interation_just_ended)
            {
                Debug.Log("Lucky Text");

                click.current_text = lucky_where_to;
                click.type_of_text = "npc";
                click.text_being_displayed = true;
                click.counter = 0;
                click.StartDialog();
                lucky_text = true;
            }
            
        }

        if (lucky_text)
        {
            dog.SetActive(true);
            dog_animator.SetBool("isFree", true);
            dog_animator.SetBool("isRunning", true);
            dog_animator.SetBool("hasTeddy", true);
            dog.transform.position = Vector3.Lerp(dog.transform.position, dog_pos.position, (7 / Vector3.Distance(dog.transform.position, dog_pos.position)) * Time.deltaTime);
            if (dog.transform.position == dog_pos.position)
            {
                dog.SetActive(false);
            }
        }
    }

}
