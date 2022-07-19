using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bear_interaction : MonoBehaviour
{
    //SCRIPTS
    cutscene_manager cutscene;
    public ClickManager click;
    public UI_Controller ui;
    //TEXT
    public interactions_text bear_inspect;
    //OBJECTS
    public GameObject bear_inspect_obj;
    public GameObject bear_pickUp;

    bool destroyed_objects = false;

    private void Start()
    {
        cutscene = GameObject.Find("Cutscene_Manager(Clone)").GetComponent<cutscene_manager>();
        //House done
        //Bear Gotten
        if (cutscene.bear_gotten || cutscene.house_done)
        {
            Destroy(bear_inspect_obj);
            Destroy(bear_pickUp);

            destroyed_objects = true;
        }

        if (cutscene.bear_inspected)
        {
            bear_pickUp.SetActive(true);
            bear_inspect_obj.SetActive(false);

            destroyed_objects = false;
        }

    }

    private void Update()
    {
        if (!destroyed_objects)
        {
            //Bear Inspected
            if (click.current_text == bear_inspect)
            {
                bear_inspect_obj.SetActive(false);

                cutscene.bear_inspected = true;
                bear_pickUp.SetActive(true);

                if (ui.interation_just_ended)
                {
                    click.current_text = null;
                }
            }

            //Bear Pickup
            if (cutscene.bear_inspected)
            {
                if (!bear_pickUp.activeSelf)
                {
                    cutscene.bear_gotten = true;
                }
            }
        }

    }
}
