using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Inventory_HoverHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public GameObject description_box;
    public Sprite _selected_sprite;
    Sprite _original_sprite;

    public ClickManager click;

    public void SetOriginalTexture()
    {
        if(_original_sprite != null)
        {
            gameObject.GetComponent<Image>().sprite = _original_sprite;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!click.selected_slot)
        {
            if (description_box != null)
            {
                if (description_box.GetComponent<inventory_item_holder>().pick_Up != null)
                {
                    if (gameObject.GetComponent<Image>().sprite != _selected_sprite)
                    {
                        _original_sprite = gameObject.GetComponent<Image>().sprite;
                    }
                    gameObject.GetComponent<Image>().sprite = _selected_sprite;

                    click.selected_slot = true;
                    click.my_selected_item = description_box.GetComponent<inventory_item_holder>().pick_Up;
                }
            }
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (description_box != null)
        {
            if (description_box.GetComponent<inventory_item_holder>().pick_Up != null)
            {

                description_box.SetActive(true);
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (description_box != null)
        {
            description_box.SetActive(false);

        }
    }

    private void OnDisable()
    {
        SetOriginalTexture();

        click.selected_slot = false;
        click.my_selected_item = null;
    }
}
