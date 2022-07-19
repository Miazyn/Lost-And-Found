using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{

    public UI_Controller ui;
    public player_movement player;
    public inventory_player player_inv;
    GameObject curObject;
    GameObject curchild;
    GameObject playerMoveTo;

    public interactions_text current_text;
    public string type_of_text;
    public bool text_being_displayed = false;
    public int counter = 0;

    public bool selected_slot = false;
    public pick_up_interactable my_selected_item;
    public GameObject inventory_panel;

    public interactions_text johan_default_no;
    public MovingTags move_scene;

    cutscene_manager cutscene;

    private void Start()
    {
        cutscene = GameObject.Find("Cutscene_Manager(Clone)").GetComponent<cutscene_manager>();
    }
    void Update()
    {
        if (ui.can_continue_text)
        {
            if (!player.is_in_cutscene)
            {
                if (!ui.ui_menu_open)
                {
                    RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                    if (selected_slot)
                    {
                        inventory_panel.SetActive(false);
                        #region[Got item for task?]
                        if (hit.collider != null && Input.GetMouseButtonDown(0))
                        {
                            if (hit.collider.CompareTag("_npc"))
                            {

                                Debug.Log(my_selected_item);
                                if (hit.collider.GetComponent<task_holder>() != null)
                                {
                                    //Do have Item
                                    if (hit.collider.GetComponent<task_holder>().my_task.item_to_fullfill_task == my_selected_item)
                                    {
                                        player_inv.RemoveItem(my_selected_item);

                                        current_text = hit.collider.GetComponent<task_holder>().my_task.fullfilled_task_text;
                                        Destroy(hit.collider.GetComponent<task_holder>());
                                        type_of_text = "npc";
                                        text_being_displayed = true;
                                        counter = 0;
                                    }

                                    //DO no have Item
                                    if (hit.collider.GetComponent<task_holder>().my_task.item_to_fullfill_task != my_selected_item)
                                    {
                                        if (hit.collider.GetComponent<npc_text_holder>() != null)
                                        {
                                            current_text = hit.collider.GetComponent<npc_text_holder>().npc_Interactable.default_response;
                                            type_of_text = "npc";
                                            text_being_displayed = true;

                                            counter = 0;
                                        }
                                    }
                                }
                                else
                                {
                                    //Random NPC, Does not take Item
                                    if (hit.collider.GetComponent<npc_text_holder>() != null)
                                    {
                                        current_text = hit.collider.GetComponent<npc_text_holder>().npc_Interactable.default_response;
                                        type_of_text = "npc";
                                        text_being_displayed = true;

                                        counter = 0;
                                    }
                                }


                            }
                            #endregion
                        }

                        #region[Hit nothing]
                        if (hit.collider == null && Input.GetMouseButtonDown(0))
                        {
                            current_text = johan_default_no;
                            type_of_text = "npc";
                            text_being_displayed = true;

                            counter = 0;
                        }
                        #endregion
                    }
                    else
                    {
                        inventory_panel.SetActive(true);
                    }

                    if (hit.collider != null && !selected_slot && ui.can_continue_text)
                    {

                        #region[show symbols]
                        if (hit.collider.gameObject.CompareTag("_inspect"))
                        {
                            if (hit.collider.gameObject.transform.GetChild(0) != null)
                            {
                                curchild = hit.collider.gameObject.transform.GetChild(0).gameObject;
                                curchild.SetActive(true);
                            }
                        }
                        else if (hit.collider.gameObject.CompareTag("_pickup"))
                        {
                            if (hit.collider.gameObject.transform.GetChild(0) != null)
                            {
                                curchild = hit.collider.gameObject.transform.GetChild(0).gameObject;
                                curchild.SetActive(true);
                            }
                        }
                        else
                        {
                            if (curchild != null)
                            {
                                curchild.SetActive(false);
                                curchild = null;
                            }
                        }
                        #endregion

                        // INPUT BUTTON
                        if (Input.GetMouseButtonDown(0) && !text_being_displayed)
                        {
                            if (text_being_displayed)
                            {

                                if (current_text.lines.Length > counter)
                                {
                                    ui.DisplayDialog(current_text, type_of_text, counter);
                                    counter++;
                                }
                                else if (current_text.lines.Length == counter)
                                {
                                    ui.DisplayDialog(current_text, type_of_text, counter);

                                    text_being_displayed = false;


                                    counter = 0;

                                    if (current_text.follow_up_text != null)
                                    {
                                        current_text = current_text.follow_up_text;
                                        StartDialog();
                                    }
                                }
                                else if (current_text.lines.Length <= counter)
                                {

                                    ui.DisplayDialog(current_text, type_of_text, counter);
                                    text_being_displayed = false;
                                    counter = 0;

                                    current_text = null;
                                }

                            }
                            if (!text_being_displayed)
                            {
                                if (hit.collider.CompareTag("_npc"))
                                {
                                    curObject = hit.collider.gameObject;
                                    //Check for position inside of Child here.
                                    type_of_text = "npc";
                                    current_text = curObject.GetComponent<npc_text_holder>().npc_Interactable.dialog_with_npc;

                                    if (curObject.transform.GetChild(1) != null)
                                    {
                                        playerMoveTo = curObject.transform.GetChild(1).gameObject;
                                    }
                                    else
                                    {
                                        Debug.LogWarning("No Pos for player to move to!");
                                    }

                                    if (player.transform.position != playerMoveTo.transform.position)
                                    {
                                        player.movingToLocation(playerMoveTo.transform);

                                    }
                                }

                                if (hit.collider.CompareTag("_inspect"))
                                {
                                    curObject = hit.collider.gameObject;
                                    //Check for position inside of Child here.
                                    type_of_text = "inspect";
                                    current_text = curObject.GetComponent<inspect_text_holder>().inspect_Interactable.description_on_inspection;
                                    var checkChild = curObject.transform.GetChild(1);
                                    if (checkChild != null)
                                    {
                                        playerMoveTo = checkChild.gameObject;
                                        if (player.transform.position != playerMoveTo.transform.position)
                                        {
                                            player.movingToLocation(playerMoveTo.transform);
                                        }
                                    }
                                    else if (player.transform.position != curObject.transform.position)
                                    {
                                        player.movingToLocation(curObject.transform);
                                    }
                                }

                                if (hit.collider.CompareTag("_pickup"))
                                {
                                    curObject = hit.collider.gameObject;

                                    type_of_text = "pickup";

                                    if (curObject.transform.position != player.transform.position)
                                    {
                                        player.movingToLocation(curObject.transform);
                                    }
                                }

                                if (hit.collider.CompareTag("_move_left"))
                                {
                                    Debug.Log("Load left");
                                    type_of_text = "moveL";
                                    curObject = hit.collider.gameObject;
                                    cutscene.loadedLeft = true;
                                    if (player.transform.position != curObject.transform.position)
                                    {
                                        player.movingToLocation(curObject.transform);
                                    }

                                }
                                if (hit.collider.CompareTag("_move_right"))
                                {
                                    cutscene.loadedLeft = false;
                                    type_of_text = "moveR";
                                    curObject = hit.collider.gameObject;

                                    if (player.transform.position != curObject.transform.position)
                                    {
                                        player.movingToLocation(curObject.transform);
                                    }
                                }

                                if (hit.collider.CompareTag("_to_robinson"))
                                {
                                    type_of_text = "rob";
                                    curObject = hit.collider.gameObject;

                                    if (player.transform.position != curObject.transform.position)
                                    {
                                        player.movingToLocation(curObject.transform);
                                    }
                                }

                                if (hit.collider.CompareTag("_from_robinson"))
                                {
                                    type_of_text = "from_rob";
                                    curObject = hit.collider.gameObject;

                                    if (player.transform.position != curObject.transform.position)
                                    {
                                        player.movingToLocation(curObject.transform);
                                    }
                                }

                                if (hit.collider.CompareTag("_final_left"))
                                {
                                    move_scene.loadingFinalLeft();
                                }
                                if (hit.collider.CompareTag("_final_right"))
                                {
                                    move_scene.loadingFinalRight();
                                }
                            }
                        }

                        #region[Check player pos]
                        if (curObject != null && !player.moveToObject)
                        {
                            if (type_of_text == "npc")
                            {
                                if (player.transform.position == playerMoveTo.transform.position)
                                {

                                    playerMoveTo = null;
                                    StartDialog();
                                }
                            }
                            else if (type_of_text == "inspect")
                            {
                                if (playerMoveTo != null)
                                {
                                    if (player.transform.position == playerMoveTo.transform.position)
                                    {
                                        playerMoveTo = null;
                                        StartDialog();
                                    }
                                }
                                else if (player.transform.position == curObject.transform.position)
                                {
                                    curObject = null;
                                    StartDialog();
                                }
                            }
                            else if (type_of_text == "pickup")
                            {
                                if (player.transform.position == curObject.transform.position)
                                {
                                    
                                    player_inv.AddItem(curObject.GetComponent<pick_up_holder>().pick_Up_Interactable);
                                    curObject.SetActive(false);
                                    curObject = null;
                                    StartCoroutine(ui.AddedToInv());
                                }
                            }
                            else if (type_of_text == "moveR")
                            {
                                if (player.transform.position == curObject.transform.position)
                                {

                                    curObject = null;
                                    move_scene.loadingRightScene();
                                }
                            }

                            else if (type_of_text == "moveL")
                            {
                                if (player.transform.position == curObject.transform.position)
                                {

                                    curObject = null;
                                    move_scene.loadingLeftScene();
                                }
                            }else if(type_of_text == "rob")
                            {
                                if (player.transform.position == curObject.transform.position)
                                {

                                    curObject = null;
                                    move_scene.robinsonLoad();
                                }
                            }
                            else if(type_of_text == "from_rob")
                            {
                                if (player.transform.position == curObject.transform.position)
                                {

                                    cutscene.loadedLeft = true;
                                    curObject = null;
                                    move_scene.robinsonLoad();
                                }
                            }
                        }
                        #endregion
                    }

                    if (curchild != null && hit.collider == null)
                    {
                        curchild.SetActive(false);
                        curchild = null;
                    }

                    #region[Check player pos]
                    if (curObject != null && !player.moveToObject)
                    {
                        if (type_of_text == "npc")
                        {
                            if (player.transform.position == playerMoveTo.transform.position)
                            {
                                playerMoveTo = null;
                                StartDialog();
                            }
                        }
                        else if (type_of_text == "inspect")
                        {
                            if (playerMoveTo != null)
                            {
                                if (player.transform.position == playerMoveTo.transform.position)
                                {
                                    playerMoveTo = null;
                                    StartDialog();
                                }
                            }
                            else if (player.transform.position == curObject.transform.position)
                            {
                                curObject = null;
                                StartDialog();
                            }
                        }
                        else if (type_of_text == "pickup")
                        {
                            if (player.transform.position == curObject.transform.position)
                            {
                                
                                player_inv.AddItem(curObject.GetComponent<pick_up_holder>().pick_Up_Interactable);
                                curObject.SetActive(false);
                                curObject = null;
                                StartCoroutine(ui.AddedToInv());

                            }
                        }
                        else if (type_of_text == "moveR")
                        {
                            if (player.transform.position == curObject.transform.position)
                            {

                                curObject = null;
                                move_scene.loadingRightScene();
                            }
                        }

                        else if (type_of_text == "moveL")
                        {
                            if (player.transform.position == curObject.transform.position)
                            {

                                curObject = null;
                                move_scene.loadingLeftScene();
                            }
                        }
                        else if (type_of_text == "rob")
                        {
                            if (player.transform.position == curObject.transform.position)
                            {

                                curObject = null;
                                move_scene.robinsonLoad();
                            }
                        }
                        else if (type_of_text == "from_rob")
                        {
                            if (player.transform.position == curObject.transform.position)
                            {

                                cutscene.loadedLeft = true;
                                curObject = null;
                                move_scene.robinsonLoad();
                            }
                        }
                    }
                    #endregion

                    if (text_being_displayed)
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            if (current_text.lines.Length > counter)
                            {
                                ui.DisplayDialog(current_text, type_of_text, counter);
                                counter++;
                            }
                            else if (current_text.lines.Length == counter)
                            {
                                ui.DisplayDialog(current_text, type_of_text, counter);

                                text_being_displayed = false;


                                counter = 0;

                                if (current_text.follow_up_text != null)
                                {
                                    current_text = current_text.follow_up_text;
                                    StartDialog();
                                }
                            }
                            else if (current_text.lines.Length <= counter)
                            {

                                ui.DisplayDialog(current_text, type_of_text, counter);
                                text_being_displayed = false;
                                counter = 0;
                                current_text = null;
                            }
                        }
                    }
                }
            }
        }
    }


    public void StartDialog()
    {
        ui.DisplayDialog(current_text, type_of_text, counter);
        curObject = null;
        text_being_displayed = true;
        counter++;
    }
}
