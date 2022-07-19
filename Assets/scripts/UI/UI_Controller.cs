using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Controller : MonoBehaviour
{
    public GameObject mainCanvas;
    public bool interation_just_ended = false;

    public GameObject menu_panel;
    public bool ui_menu_open = false;
    public GameObject inventory_button;
    public GameObject inside_inventory;
    public bool is_open_inventory = false;

    //Tasks
    List<task> task_list;
    public GameObject task1, task2, task3;
    public Text[] tasks_text;

    //Texts
    public GameObject TextBox;
    public GameObject text_box_name;
    public GameObject text_field_npc;
    public GameObject text_field_inspect;
    public float typing_speed = 0.01f;

    public Text npc_text;
    public Text inspect_text;
    public Text npc_name_text;

    Coroutine displayCoroutine;

    public bool can_continue_text = true;


    private void Start()
    {
        tasks_text = new Text[3];

        tasks_text[0] = task1.transform.GetChild(0).gameObject.GetComponent<Text>();
        tasks_text[1] = task2.transform.GetChild(0).gameObject.GetComponent<Text>();
        tasks_text[2] = task3.transform.GetChild(0).gameObject.GetComponent<Text>();

        if (inside_inventory == null)
        {
            Debug.LogWarning("No Inside of Inventory defined.");
        }
        inside_inventory.SetActive(false);

        if(menu_panel != null)
        {
            menu_panel.SetActive(false);

        }
        else { Debug.LogWarning("No Menu defined."); }
    }

    //Functions: OpenInventory(); OpenMenu(); SelectItem(); Settings(); ContinueGame(); ReceiveTask(); TypeEffect();
    private void Update()
    {
    }

    public void OpenInventory() {
        if (inside_inventory.activeSelf)
        {
            is_open_inventory = false;
            inside_inventory.SetActive(false);
            interation_just_ended = true;
        }
        else
        {
            is_open_inventory = true;
            inside_inventory.SetActive(true);
        }
    
    }
    public void OpenMenu() {
        
        if (menu_panel.activeSelf)
        {
            menu_panel.SetActive(false);
            ui_menu_open = false;
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
            ui_menu_open = true;
            menu_panel.SetActive(true);
        }
        interation_just_ended = true;

    }

    public void DisplayDialog(interactions_text text_to_display, string type, int counter)
    {
        if (inside_inventory.activeSelf)
        {
            inside_inventory.SetActive(false);
            is_open_inventory = false;
        }

        if (text_to_display.lines.Length > counter)
        {

            TextBox.SetActive(true);
            if (type == "npc")
            {

                text_box_name.SetActive(true);
                text_field_npc.SetActive(true);

                //npc_text.text = text_to_display.lines[counter];
                npc_name_text.text = text_to_display.name_des_npc;

            }
            if (type == "inspect")
            {
                text_field_inspect.SetActive(true);

                //inspect_text.text = text_to_display.lines[counter];

            }

            if (displayCoroutine != null)
            {
                StopCoroutine(TypeEffect(text_to_display.lines[counter], type));
            }
            displayCoroutine = StartCoroutine(TypeEffect(text_to_display.lines[counter],type));
        }
        else
        {
            
            interation_just_ended = true;
            TextBox.SetActive(false);
            text_box_name.SetActive(false);
            text_field_inspect.SetActive(false);
            text_field_npc.SetActive(false);
        }

    }

    public void SelectedItem() { }
    public void Settings() { }
    
    public void ToTitle()
    {
        Destroy(this);
        SceneManager.LoadScene("Main_Menu", LoadSceneMode.Single);
    }
    public void ReceiveTask() { }
    public IEnumerator TypeEffect(string line, string type) 
    {
        can_continue_text = false;
        if(type == "inspect")
        {
            inspect_text.text = "";
            for(int i = 0; i < line.ToCharArray().Length; i++)
            {
                inspect_text.text += line.ToCharArray()[i];
                yield return new WaitForSeconds(typing_speed);
            }
        }
        if(type == "npc")
        {
            npc_text.text = "";
            for (int i = 0; i < line.ToCharArray().Length; i++)
            {
                npc_text.text += line.ToCharArray()[i];
                yield return new WaitForSeconds(typing_speed);
            }
        }
        can_continue_text = true;
    }
    public void QuitGame() { Application.Quit(); }

    public IEnumerator AddedToInv()
    {
        inventory_button.GetComponent<Image>().color = Color.gray;
        yield return new WaitForSeconds(0.1f);
        inventory_button.GetComponent<Image>().color = Color.white;
        yield return new WaitForSeconds(0.1f);
        inventory_button.GetComponent<Image>().color = Color.gray;
        yield return new WaitForSeconds(0.1f);
        inventory_button.GetComponent<Image>().color = Color.white;
    }

    public void NewTask(task task)
    {
        //Set Up New Task;
        foreach(task myTask in task_list)
        {
            if(myTask == task)
            {
                break;
            }
        }
        task_list.Add(task);
        WipeTasks(task);
    }

    public void WipeTasks(task task)
    {
        
        for(int i = 0; i <tasks_text.Length; i++)
        {
            tasks_text[i].text = "";
        }

        AddTask(task);

    }
    public void AddTask(task task)
    {
        int counter = 0;
        foreach(task myTask in task_list)
        {
            tasks_text[counter].text = myTask.task_text;
            if (tasks_text[counter].text != "")
            {
                tasks_text[counter].gameObject.SetActive(true);
            }
            counter++;
        }

    }

}
