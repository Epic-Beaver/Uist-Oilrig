using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherControler : MonoBehaviour
{

    public bool goodWeather = true;

    public bool allowFog = true;
    private ParticleSystem ps;
    public float fogDensity = 0.1f;

    public Material goodSky;
    public Material badSky;

    void Start()
    {
        ps = gameObject.GetComponent<ParticleSystem>();
        updateWeather();
    }


    void updateWeather()
    {
        if (goodWeather)
        {
            setGoodWeather();
        }
        else
        {
            setBadWeather();
        }
    }

    void setBadWeather()
    {
        RenderSettings.fog = allowFog;
        var emission = ps.emission;
        emission.enabled = true;
        RenderSettings.skybox = badSky;
    }

    void setGoodWeather()
    {
        RenderSettings.fog = false;
        var emission = ps.emission;
        emission.enabled = false;
        ps.Clear();
        RenderSettings.skybox = goodSky;
    }
}
