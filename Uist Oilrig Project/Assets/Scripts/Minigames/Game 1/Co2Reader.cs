using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Co2Reader : MonoBehaviour
{
    public string defaultText = "C02 Emissions:";
    private Text displayText;
    private int co2Time;

    public Grabber grab;
    public Pickup_Entity entity;

    // Start is called before the first frame update
    void Start()
    {
        displayText = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        co2Time++;
        displayText.text = defaultText + " " + (int) (grab.co2Time + entity.co2Time + co2Time);
    }
}
