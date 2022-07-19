using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralManager : MonoBehaviour
{
    #region[VarDeclaration]
    public List<pick_up_interactable> pick_Up_Interactables_list;

    public GameObject prefab_manager;

    #endregion
    private void Awake()
    {
        var findme = GameObject.Find("Cutscene_Manager");
        var findclone = GameObject.Find("Cutscene_Manager(Clone)");
        if(findme == null && findclone == null)
        {
            Instantiate(prefab_manager);
        }
    }
}
