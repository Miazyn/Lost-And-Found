using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InspectObject", menuName = "ScriptableObjects/Interactable/Inspect")]
public class inspect_interactable : interactables
{
    [Tooltip("Text shown when inspecting this item.")]
    public interactions_text description_on_inspection;
}
