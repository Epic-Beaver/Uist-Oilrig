using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherReceiver : MonoBehaviour
{
    //Weather Values:
    //0 - Clear
    //1 - Disabled
    //For Fog, Rain or wind. 0 is none, 1 is enabled.

    public int fog;
    public int rain;
    public int wind;

    public bool changed = true;

    private OceanSway[] waveObjects;

    public WeatherControler weather;

    void FixedUpdate()
    {
        if (changed)
        {
            fog = PlayerPrefs.GetInt("Fog");
            rain = PlayerPrefs.GetInt("Rain");
            wind = PlayerPrefs.GetInt("Wind");

            waveObjects = FindObjectsOfType<OceanSway>();

            foreach (OceanSway obj in waveObjects)
            {
                obj.horStrength *= wind;
                obj.vertStrength *= wind;
            }

            weather.fogDensity *= fog;

            if (rain > 0)
            {
                weather.isRaining = true;
            }
            else
            {
                weather.isRaining = false;
            }

            if (rain + fog + wind == 0)
            {
                weather.isGoodWeather = true;
            }
            else
            {
                weather.isGoodWeather = false;
            }

            weather.updateWeather();
            changed = false;
        } 
    }
}
