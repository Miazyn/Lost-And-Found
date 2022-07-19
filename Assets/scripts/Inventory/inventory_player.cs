using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventory_player : MonoBehaviour
{
    public List<pick_up_interactable> inventory_list;
    public GeneralManager manager;
    public AudioSource inventorySound;

    public GameObject InventorySlots;
    GameObject[] slots;

    public GameObject Descriptions;
    GameObject[] descs;

    Sprite no_sprite;
    public Color none_color;

    cutscene_manager cutscene;

    public pick_up_interactable bear, key, newspapers, food_card;

    private void Start()
    {
        cutscene = GameObject.Find("Cutscene_Manager(Clone)").GetComponent<cutscene_manager>();
        inventory_list = new List<pick_up_interactable>();
        //SETUP
        if (cutscene.bear_gotten)
        {
            inventory_list.Add(bear);
        }
        if (cutscene.key_gotten)
        {
            inventory_list.Add(key);
        }
        //Newspaper and food_card to be added;

        


        no_sprite = null;
        slots = new GameObject[5];
        descs = new GameObject[5];
        none_color = new Color(0, 0, 0, 0);
        slots[0] = InventorySlots.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
        slots[1] = InventorySlots.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject;
        slots[2] = InventorySlots.transform.GetChild(2).gameObject.transform.GetChild(0).gameObject;
        slots[3] = InventorySlots.transform.GetChild(3).gameObject.transform.GetChild(0).gameObject;
        slots[4] = InventorySlots.transform.GetChild(4).gameObject.transform.GetChild(0).gameObject;

        descs[0] = Descriptions.transform.GetChild(0).gameObject;
        descs[1] = Descriptions.transform.GetChild(1).gameObject;
        descs[2] = Descriptions.transform.GetChild(2).gameObject;
        descs[3] = Descriptions.transform.GetChild(3).gameObject;
        descs[4] = Descriptions.transform.GetChild(4).gameObject;
        StartInventory();
    }
    //Functions: AddItem(), RemoveItem(), OnDestroy()=> transfer List
    public void StartInventory()
    {
        int counter = 0;
        if (cutscene.bear_gotten)
        {
            slots[counter].GetComponent<Image>().sprite = bear.inventory_sprite;
            slots[counter].GetComponent<Image>().color = Color.white;

            descs[counter].transform.GetChild(0).gameObject.GetComponent<Text>().text = bear.name_of_object + "\n" + bear.description_of_object;
            descs[counter].GetComponent<inventory_item_holder>().pick_Up = bear;
            counter++;
        }
        if (cutscene.key_gotten && !cutscene.key_used)
        {
            slots[counter].GetComponent<Image>().sprite = key.inventory_sprite;
            slots[counter].GetComponent<Image>().color = Color.white;

            descs[counter].transform.GetChild(0).gameObject.GetComponent<Text>().text = key.name_of_object + "\n" + key.description_of_object;
            descs[counter].GetComponent<inventory_item_holder>().pick_Up = key;
            counter++;
        }
        if (cutscene.gotNewspaper && !cutscene.used_newspaper)
        {
            slots[counter].GetComponent<Image>().sprite = newspapers.inventory_sprite;
            slots[counter].GetComponent<Image>().color = Color.white;

            descs[counter].transform.GetChild(0).gameObject.GetComponent<Text>().text = newspapers.name_of_object + "\n" + newspapers.description_of_object;
            descs[counter].GetComponent<inventory_item_holder>().pick_Up = newspapers;
            counter++;
        }
        if(cutscene.got_food_card && !cutscene.used_food_card)
        {
            slots[counter].GetComponent<Image>().sprite = food_card.inventory_sprite;
            slots[counter].GetComponent<Image>().color = Color.white;

            descs[counter].transform.GetChild(0).gameObject.GetComponent<Text>().text = food_card.name_of_object + "\n" + food_card.description_of_object;
            descs[counter].GetComponent<inventory_item_holder>().pick_Up = food_card;
            counter++;
        }
    }

    public void WipeInventory()
    {

        for (int i = 0; i < inventory_list.Count; i++)
        {
            slots[i].GetComponent<Image>().sprite = no_sprite;
            slots[i].GetComponent<Image>().color = none_color;

            descs[i].transform.GetChild(0).gameObject.GetComponent<Text>().text = "";
            descs[i].GetComponent<inventory_item_holder>().pick_Up = null;

        }
        SetUpInventory();
    }

    public void SetUpInventory()
    {
        for(int i = 0; i < inventory_list.Count; i++)
        {
            slots[i].GetComponent<Image>().sprite = inventory_list[i].inventory_sprite;
            slots[i].GetComponent<Image>().color = Color.white;

            descs[i].transform.GetChild(0).gameObject.GetComponent<Text>().text = inventory_list[i].name_of_object + "\n" + inventory_list[i].description_of_object;
            descs[i].GetComponent<inventory_item_holder>().pick_Up = inventory_list[i];
        }

    }

    public void AddItem(pick_up_interactable item)
    {
        if (inventorySound != null)
        {
            inventorySound.Play();
        }
        inventory_list.Add(item);
        WipeInventory();
    }

    public void RemoveItem(pick_up_interactable myitem)
    {
        for (int i = 0; i < inventory_list.Count; i++)
        {
            if (inventory_list[i] == myitem)
            {
                inventory_list.RemoveAt(i);
            }
        }


        WipeInventory();
    }

    private void OnDestroy()
    {
    }
}
