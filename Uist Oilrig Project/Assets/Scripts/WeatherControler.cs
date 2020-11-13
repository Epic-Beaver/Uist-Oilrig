using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeatherControler : MonoBehaviour
{

    public static bool goodWeather;
    public bool isGoodWeather = true;

    public bool isRaining;

    public bool allowFog = true;
    private ParticleSystem ps;
    public float fogDensity = 0.1f;

    public Material goodSky;
    public Material badSky;

    void Awake()
    {
        goodWeather = isGoodWeather;
        print("1 good weather " + goodWeather + "\n");
        print("1 is good weather " + isGoodWeather + "\n");
    }

    void Start()
    {
        print("2 good weather " + goodWeather + "\n");
        print("2 is good weather " + isGoodWeather + "\n");
        ps = gameObject.GetComponent<ParticleSystem>();
        updateWeather();
    }


    public void updateWeather()
    {
        if (isGoodWeather)
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
        RenderSettings.fogDensity = fogDensity;
        RenderSettings.fog = allowFog;
        var emission = ps.emission;
        RenderSettings.skybox = badSky;

        if (isRaining)
        {
            ps.Play();
            emission.enabled = true;

        }
        else
        {
            ps.Clear();
            emission.enabled = false;
        }
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
