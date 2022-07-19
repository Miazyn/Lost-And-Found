using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robinson_cut : MonoBehaviour
{
    cutscene_manager cutscene;
    public ClickManager click;
    public UI_Controller ui;

    public GameObject card_pick;
    public GameObject card_inspect;

    public Animator old_man;
    public interactions_text gave_newspaper;

    private void Start()
    {
        cutscene = GameObject.Find("Cutscene_Manager(Clone)").GetComponent<cutscene_manager>();
        if (cutscene.used_newspaper && !cutscene.got_food_card)
        {
            old_man.SetBool("gotPaper", true);
            card_inspect.SetActive(false);
            card_pick.SetActive(true);
        }



        if (cutscene.got_food_card)
        {
            card_inspect.SetActive(false);
            card_pick.SetActive(false);
            old_man.SetBool("gotPaper", true);
        }
    }

    private void Update()
    {
        if(click.current_text == gave_newspaper)
        {
            if (ui.interation_just_ended)
            {
                card_pick.SetActive(true);
                card_inspect.SetActive(false);
                old_man.SetBool("gotPaper", true);
                cutscene.used_newspaper = true;
            }
        }

        if (cutscene.used_newspaper && !cutscene.got_food_card)
        {
            if (!card_pick.activeSelf)
            {
                cutscene.got_food_card = true;
            }
        }
    }
}
