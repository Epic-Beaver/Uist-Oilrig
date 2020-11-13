using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherSender : MonoBehaviour
{
    private void Start()
    {
        PlayerPrefs.SetInt("Fog", 0);
        PlayerPrefs.SetInt("Rain", 0);
        PlayerPrefs.SetInt("Wind", 0);
    }

    public void setFog(bool fog)
    {
        if (fog)
        {
            PlayerPrefs.SetInt("Fog", 1);
        } else
        {
            PlayerPrefs.SetInt("Fog", 0);
        }
    }

    public void setRain(bool rain)
    {
        if (rain)
        {
            PlayerPrefs.SetInt("Rain", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Rain", 0);
        }
    }

    public void setWind(bool wind)
    {
        if (wind)
        {
            PlayerPrefs.SetInt("Wind", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Wind", 0);
        }
    }
}
