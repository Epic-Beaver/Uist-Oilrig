using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherPhysics : MonoBehaviour
{
    // Start is called before the first frame update
    List<GameObject> physicsObjects;

    public float weatherDrag = 0.5f;
    public float weatherGravity = 0.8f;

    public float normalDrag = 0.8f;
    public float normalGravity = 1f;

    public PhysicsMaterial2D normal, slippery;
    void Start()
    {
        physicsObjects = AllChilds(gameObject);
        if (!WeatherControler.goodWeather)
        {
            print("bad Weather \n");
            setWeatherElements(weatherDrag, weatherGravity, slippery);
        }
        else
        {
            print("good Weather \n");
            setWeatherElements(normalDrag, normalGravity, normal);
        }
    }

    void setWeatherElements(float drag, float gravity, PhysicsMaterial2D material) 
    { 
        foreach(GameObject currentObject in physicsObjects)
        {
            setWeatherValues(currentObject, drag, gravity);
            setWeatherMaterial(currentObject, material);
        }
    }

    void setWeatherValues(GameObject currentObject, float drag, float gravity)
    {
        Rigidbody2D temp = currentObject.GetComponent<Rigidbody2D>();
        temp.drag = drag;
        temp.angularDrag = drag;
        temp.gravityScale = gravity;
    }
    void setWeatherMaterial(GameObject currentObject, PhysicsMaterial2D material)
    {
        BoxCollider2D temp = currentObject.GetComponent<BoxCollider2D>();
        temp.sharedMaterial = material;
    }





    private List<GameObject> AllChilds(GameObject root)
    {
        List<GameObject> result = new List<GameObject>();
        if (root.transform.childCount > 0)
        {
            foreach (Transform VARIABLE in root.transform)
            {
                Searcher(result, VARIABLE.gameObject);
            }
        }
        return result;
    }

    private void Searcher(List<GameObject> list, GameObject root)
    {
        list.Add(root);
        if (root.transform.childCount > 0)
        {
            foreach (Transform VARIABLE in root.transform)
            {
                Searcher(list, VARIABLE.gameObject);
            }
        }
    }

}
