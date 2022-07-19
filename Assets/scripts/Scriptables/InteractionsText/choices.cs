using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Choice", menuName = "ScriptableObjects/Interaction/Choice")]
public class choices : ScriptableObject
{
    public string choice_text;
    public interactions_text follow_up_text_upon_choice;
}
