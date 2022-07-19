using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_street_lady : MonoBehaviour
{
    public cutscene_manager cutscene;
    public ClickManager click;
    public player_movement player;

    private void Start()
    {
        cutscene = GameObject.Find("Cutscene_Manager(Clone)").GetComponent<cutscene_manager>();

        if (cutscene.main_street_lady_done)
        {
            Destroy(this);
        }
        else
        {
            cutscene_now();
        }
    }

    public void cutscene_now()
    {
        click.current_text = gameObject.GetComponent<npc_text_holder>().npc_Interactable.dialog_with_npc;
        click.type_of_text = "npc";
        click.text_being_displayed = true;
        click.counter = 0;
        click.StartDialog();
        cutscene.main_street_lady_done = true;
    }
}
