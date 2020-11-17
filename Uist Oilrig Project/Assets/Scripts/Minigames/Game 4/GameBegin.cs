using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameBegin : MonoBehaviour
{
    public GameObject button;
    public Text icon1;
    public Text icon2;
    public Text icon3;
    public Text icon4;

    // Start is called before the first frame update
    void Start()
    {
        button.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(icon1.enabled && icon2.enabled && icon3.enabled && icon4.enabled)
        {
            button.SetActive(true);
        }
    }
}
