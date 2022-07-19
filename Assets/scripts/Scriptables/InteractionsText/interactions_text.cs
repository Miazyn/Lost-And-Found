using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Text", menuName = "ScriptableObjects/Interaction/Text")]
public class interactions_text : ScriptableObject
{
    [Tooltip("Falls ein Npc redet fülle hier den Namen aus, sonst leer lassen.")]
    public string name_des_npc;
    [TextArea(5, 20)]
    public string[] lines;

    public choices[] choice_options;

    [Tooltip("Text der angezeigt wird nachdem alle Linien abgebaut sind.")]
    public interactions_text follow_up_text;



}
