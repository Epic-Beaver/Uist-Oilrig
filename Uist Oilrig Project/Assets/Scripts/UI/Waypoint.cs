using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Waypoint : MonoBehaviour
{
    public RectTransform prefab;
    private RectTransform waypoint;
    private Transform player;
    private Text distanceText;
    private Vector3 offset = new Vector3(0, 1f, 0);
   
    void Start()
    {
        var canvas = GameObject.Find("Waypoints").transform;
        waypoint=Instantiate(prefab, canvas);
        player = GameObject.Find("Player").transform;
        distanceText = waypoint.GetComponentInChildren<Text>();
      //  distanceText = waypoint.GetComponent<Text>();
    }

    
    void Update()
    {
        


        var screenPos = Camera.main.WorldToScreenPoint(transform.position + offset);
        waypoint.position = screenPos;
        distanceText.text = Vector3.Distance(player.position, transform.position).ToString("0") + "m";
        waypoint.gameObject.SetActive(screenPos.z > 0);
    }
}
