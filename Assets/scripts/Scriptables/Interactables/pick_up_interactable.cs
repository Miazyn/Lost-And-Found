using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PickUpObject", menuName = "ScriptableObjects/Interactable/PickUp")]
public class pick_up_interactable : interactables
{
    [Tooltip("What is shown when you pick it up in the inventory.")]
    public Sprite inventory_sprite;

    public string name_of_object;
    [TextArea(5, 20)]
    public string description_of_object;

}
