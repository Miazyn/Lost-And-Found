using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Task", menuName = "ScriptableObjects/Interaction/Task")]
public class task : ScriptableObject
{

    public string task_text;
    public pick_up_interactable item_to_fullfill_task;

    public interactions_text fullfilled_task_text;

}
