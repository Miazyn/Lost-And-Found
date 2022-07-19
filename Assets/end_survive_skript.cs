using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class end_survive_skript : MonoBehaviour
{
    public GameObject imag1, img2, img3, panel;


    private void Start()
    {
        StartCoroutine(end());
    }

    IEnumerator end()
    {
        yield return new WaitForSeconds(7f);
        imag1.SetActive(false);
        img2.SetActive(false);
        img3.SetActive(true);
        yield return new WaitForSeconds(7f);
        img3.SetActive(false);
        panel.SetActive(true);
    }
}
