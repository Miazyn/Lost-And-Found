using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NpcObject", menuName = "ScriptableObjects/Interactable/NpcObject")]
public class npc_interactable : interactables
{
    [Tooltip("Dialog which is shown when interacting with the npc.")]
    public interactions_text dialog_with_npc;

    [Tooltip("Default response when npc is shown an unrelated Object.")]
    public interactions_text default_response;
}
