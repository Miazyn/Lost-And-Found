using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class end_all_die : MonoBehaviour
{

    public GameObject image1,image2, panel;
    void Start()
    {
        StartCoroutine(end());
    }

    IEnumerator end()
    {
        yield return new WaitForSeconds(7f);
        image1.SetActive(false);
        image2.SetActive(true);
        yield return new WaitForSeconds(10f);
        image2.SetActive(false);
        panel.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
