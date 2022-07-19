using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_main_street : MonoBehaviour
{

    GameObject player;

    public Vector3 minValue, maxValue;

    cutscene_manager cutscene;
    public Transform left_pos_cam, right_pos_cam;

    private void Start()
    {
        cutscene = GameObject.Find("Cutscene_Manager(Clone)").GetComponent<cutscene_manager>();
        player = GameObject.Find("Player");

        var findleft = GameObject.Find("left_pos_cam");
        var findright = GameObject.Find("right_pos_cam");
        if (findleft != null)
        {
            left_pos_cam = findleft.GetComponent<Transform>();
            if (!cutscene.loadedLeft)
            {
                transform.position = left_pos_cam.position;
            }
        }
        if (findright != null)
        {
            right_pos_cam = findright.GetComponent<Transform>();
            if (cutscene.loadedLeft)
            {
                transform.position = right_pos_cam.position;
            }
        }

    }

    private void Update()
    {

        if (player != null)
        {
            Vector3 targetPos = player.transform.position;
            if (targetPos.x < maxValue.x && targetPos.x > minValue.x)
            {
                transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
            }
        }
    }
}
