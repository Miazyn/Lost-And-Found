using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_Main_Menu : MonoBehaviour
{

    public Vector3 minValue, maxValue;
    public float speed = 1f;
    public Vector3 target;

    private void Start()
    {
        transform.position = minValue;
    }

    private void Update()
    {
        if(transform.position == minValue)
        {
            target = maxValue;
        }
        else if(transform.position == maxValue)
        {
            target = minValue;
        }

        transform.position = Vector3.Lerp(transform.position, target, speed / Vector3.Distance(transform.position, target) * Time.deltaTime);
    }

}
