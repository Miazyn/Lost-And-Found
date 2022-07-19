using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_pos_define : MonoBehaviour
{
    GameObject player;
    MovingTags movin_scene;

    public Transform left_pos;
    public Transform right_pos;

    private void Start()
    {
        player = GameObject.Find("Player");
        movin_scene = GameObject.Find("Management").GetComponent<MovingTags>();

        if(movin_scene.prev_scene == "Scene_1_bunker")
        {
            player.transform.position = right_pos.position;
        }
        if(movin_scene.prev_scene == "Scene_3_house")
        {
            player.transform.position = left_pos.position;
        }
        if(movin_scene.prev_scene == "Scene_4_robinson")
        {
            player.transform.position = right_pos.position;
        }
    }
}
