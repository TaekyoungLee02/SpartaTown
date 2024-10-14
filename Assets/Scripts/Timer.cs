using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(timer());
    }


    private IEnumerator timer()
    {
        timerText.text = DateTime.Now.ToString("HH : mm");

        yield return new WaitForSeconds(1);
    }
}
