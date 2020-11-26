using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameBegin : MonoBehaviour
{
    public GameObject button;
    public Loading task1, task2, task3, task4;

    // Start is called before the first frame update
    void Start()
    {
        button.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(task1.complete && task2.complete && task3.complete && task4.complete)
        {
            button.SetActive(true);
        }
    }
}
