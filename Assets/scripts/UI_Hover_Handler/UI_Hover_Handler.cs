using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_Hover_Handler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public player_movement player;


    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!player.taped)
        {
            player.is_over_UI = true;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(!player.taped)
        {
            player.is_over_UI = false;
        }
    }

}
