using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Cannot create instance of object bc of the abstract
public abstract class interactables : ScriptableObject
{
    [Tooltip("What Icon shows up when you hover the object?")]
    public Sprite interactionIcon;

}
