using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    public float speed = 7;
    [SerializeField] Camera cam;
    bool player_facing_left = true;

    public Vector3 minValue, maxValue;

    float timer = 0;
    public bool taped = false;
    float tapTimer = 0.2f;
    public Vector3 curTapPosition;

    public bool is_over_UI = false;
    public GameObject Management;
    UI_Controller ui;
    public bool moveToObject = false;
    Transform ObjectPos;
    Animator player_animator, dog_animator;
    string running = "isRunning";

    ClickManager click;
    cutscene_manager cutscene;

    public bool is_in_cutscene = false;

    public Transform left_pos, right_pos;
    private void Start()
    {
       

        cutscene = GameObject.Find("Cutscene_Manager(Clone)").GetComponent<cutscene_manager>();
        ui = Management.GetComponent<UI_Controller>();
        click = Management.GetComponent<ClickManager>();
        player_animator = gameObject.GetComponent<Animator>();

        if (cutscene.gotdog)
        {
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
            dog_animator = gameObject.transform.GetChild(1).gameObject.GetComponent<Animator>();
            dog_animator.SetBool("isFree", true);
        }

        var findleft = GameObject.Find("left_pos");
        var findright = GameObject.Find("right_pos");
        if (findleft != null)
        {
            left_pos = findleft.GetComponent<Transform>();
            if (!cutscene.loadedLeft)
            {
                transform.position = left_pos.position;
            }
        }
        if (findright != null)
        {
            right_pos = findright.GetComponent<Transform>();
            if (cutscene.loadedLeft)
            {
                transform.position = right_pos.position;
            }
        }
    }

    void Update()
    {
        if (cutscene.ate_time_for_final)
        {
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }
        else if (cutscene.gotdog)
        {
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
            dog_animator = gameObject.transform.GetChild(1).gameObject.GetComponent<Animator>();
            dog_animator.SetBool("isFree", true);
        }
        cam = Camera.main;
        //Debug.Log(click.text_being_displayed + "" + ui.ui_menu_open + "" + ui.is_open_inventory + "" + moveToObject);
        //Debug.Log(is_over_UI);
        if (!is_in_cutscene && !click.text_being_displayed && !ui.ui_menu_open && !ui.is_open_inventory && ui.can_continue_text)
        {

            if (!moveToObject)
            {
                if (ui.interation_just_ended)
                {
                    curTapPosition = transform.position;
                    is_over_UI = false;
                    StartCoroutine("WaitUntilNextInteraction");
                }
                else
                {

                    if (!is_over_UI)
                    {
                        #region[Movement]
                        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
                        mousePos.z = 0;

                        if (Input.GetMouseButton(0))
                        {
                            //Increase Timer
                            timer += Time.deltaTime;

                            if (timer >= tapTimer)
                            {
                                taped = false;

                                //--- Y TEST ---//
                                if (mousePos.y < maxValue.y && mousePos.y > minValue.y)
                                {
                                    //MaxValue y can be MousePos.y
                                    curTapPosition.y = mousePos.y;
                                }
                                else if (mousePos.y < minValue.y)
                                {
                                    curTapPosition.y = minValue.y;
                                }
                                else if (mousePos.y > maxValue.y)
                                {
                                    curTapPosition.y = maxValue.y;
                                }

                                //--- X TEST ---//
                                if (mousePos.x < maxValue.x && mousePos.x > minValue.x)
                                {
                                    //Max value x can be mousePos.x
                                    curTapPosition.x = mousePos.x;
                                }
                                else if (mousePos.x > maxValue.x)
                                {
                                    curTapPosition.x = maxValue.x;
                                }
                                else if (mousePos.x < minValue.x)
                                {
                                    curTapPosition.x = minValue.x;
                                }
                                if(dog_animator != null)
                                {
                                    dog_animator.SetBool(running, true);
                                }

                                player_animator.SetBool(running, true);
                                transform.position = Vector3.Lerp(transform.position, curTapPosition, (speed / Vector3.Distance(transform.position, curTapPosition)) * Time.deltaTime);
                            }
                        }
                        if (Input.GetMouseButtonUp(0))
                        {



                            //Timer Check for tap or hold
                            if (timer <= tapTimer)
                            {
                                if (mousePos.y < maxValue.y && mousePos.y > minValue.y)
                                {
                                    //MaxValue y can be MousePos.y
                                    curTapPosition.y = mousePos.y;
                                }
                                else if (mousePos.y < minValue.y)
                                {
                                    curTapPosition.y = minValue.y;
                                }
                                else if (mousePos.y > maxValue.y)
                                {
                                    curTapPosition.y = maxValue.y;
                                }

                                //--- X TEST ---//
                                if (mousePos.x < maxValue.x && mousePos.x > minValue.x)
                                {
                                    //Max value x can be mousePos.x
                                    curTapPosition.x = mousePos.x;
                                }
                                else if (mousePos.x > maxValue.x)
                                {
                                    curTapPosition.x = maxValue.x;
                                }
                                else if (mousePos.x < minValue.x)
                                {
                                    curTapPosition.x = minValue.x;
                                }
                                taped = true;

                            }
                            else
                            {

                                taped = false;
                            }

                            //Set Timer back to 0
                            timer = 0;
                        }
                        //wenn mouse geklickt
                        if (taped)
                        {

                            if (dog_animator != null)
                            {
                                dog_animator.SetBool(running, true);
                            }
                            player_animator.SetBool(running, true);
                            transform.position = Vector3.Lerp(transform.position, curTapPosition, speed / Vector3.Distance(transform.position, curTapPosition) * Time.deltaTime);

                        }
                        #endregion
                    }
                }
            }
            else
            {
                if (ObjectPos != null)
                {
                    curTapPosition = ObjectPos.position;
                    //Move Player to Object

                    if (transform.position != ObjectPos.position)
                    {

                        if (dog_animator != null)
                        {
                            dog_animator.SetBool(running, true);
                        }
                        player_animator.SetBool(running, true);
                        transform.position = Vector3.Lerp(transform.position, curTapPosition, (speed / Vector3.Distance(transform.position, curTapPosition)) * Time.deltaTime);
                    }
                    if (transform.position == ObjectPos.position)
                    {

                        if (dog_animator != null)
                        {
                            dog_animator.SetBool(running, false);
                        }
                        player_animator.SetBool(running, false);
                        moveToObject = false;
                    }
                }
            }


            #region[Facing + Animation]
            if ((curTapPosition.x - transform.position.x) < 0)
            {

                if (!player_facing_left)
                {
                    transform.Rotate(0, 180, 0);
                    player_facing_left = true;
                }
            }
            else
            {



                if (player_facing_left && (curTapPosition.x - transform.position.x) > 0)
                {
                    player_facing_left = false;
                    transform.Rotate(0, 180, 0);
                }
            }



        }
        else
        {

            if (dog_animator != null)
            {
                dog_animator.SetBool(running, false);
            }
            player_animator.SetBool(running, false);
        }
        if (curTapPosition != null)
        {

            if (curTapPosition == transform.position)
            {

                if (dog_animator != null)
                {
                    dog_animator.SetBool(running, false);
                }
                player_animator.SetBool(running, false);
            }
        }

        if (Input.GetMouseButtonUp(0) && !taped)
        {

            if (dog_animator != null)
            {
                dog_animator.SetBool(running, false);
            }
            player_animator.SetBool(running, false);
        }
        #endregion

    }


    IEnumerator WaitUntilNextInteraction()
    {
        yield return new WaitForSeconds(0.2f);
        ui.interation_just_ended = false;
    }

    public void movingToLocation(Transform positionMove)
    {
        moveToObject = true;
        ObjectPos = positionMove;


    }
}
