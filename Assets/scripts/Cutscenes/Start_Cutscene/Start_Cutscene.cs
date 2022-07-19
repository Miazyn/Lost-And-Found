using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Start_Cutscene : MonoBehaviour
{

    public GameObject image1,image2,panel;
    public Text panel_text;

    private void Start()
    {
        StartCoroutine(StartCutscene());
    }

    IEnumerator StartCutscene()
    {
        yield return new WaitForSeconds(7f);
        image1.SetActive(false);
        image2.SetActive(true);
        yield return new WaitForSeconds(7f);
        image2.SetActive(false);
        panel.SetActive(true);
        StartCoroutine(TypingMama());
    }

    IEnumerator TypingMama()
    {
        string mama = "MAMAAA!";
        panel_text.text = "";
        foreach(var letter in mama.ToCharArray()){

            panel_text.text += letter;
            yield return new WaitForSeconds(0.1f);

        }
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Scene_1_bunker", LoadSceneMode.Single);
    }
}
