using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene_1 : MonoBehaviour
{
    interactions_text cutscene_text;

    public GameObject black_out_panel;

    public cutscene_manager cutscene;
    public GameObject player;
    public ClickManager click;

    public Transform player_pos_after;
    private void Start()
    {
        cutscene = GameObject.Find("Cutscene_Manager(Clone)").GetComponent<cutscene_manager>();
        cutscene_text = gameObject.GetComponent<npc_text_holder>().npc_Interactable.dialog_with_npc;

        if (cutscene.bunker_wake_up_done)
        {
            player.transform.position = player_pos_after.position;
            Destroy(black_out_panel);
            Destroy(this);
            //DO nothing
        }
        else
        {
           
            StartCoroutine(cutscene_1_bunker());
        }
        
    }

    IEnumerator cutscene_1_bunker()
    {
        Debug.Log("Cutscene started");
        player.GetComponent<player_movement>().is_in_cutscene = true;
        yield return new WaitForSeconds(7f);
        Destroy(black_out_panel);
        click.current_text = cutscene_text;
        click.type_of_text = "npc";
        click.text_being_displayed = true;
        click.counter = 0;
        click.StartDialog();
        cutscene.bunker_wake_up_done = true;
        player.GetComponent<player_movement>().is_in_cutscene = false;

    }
}
