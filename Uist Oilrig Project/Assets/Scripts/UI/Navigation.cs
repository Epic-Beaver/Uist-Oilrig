using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Navigation : MonoBehaviour
{

    public Image navigationItem;
    public Text textItem;
    public string units = "u";
    public float circleRadius;
    public Camera cam;

    private Vector3 screenCentre;

    private Vector3 imagePos;


    // Start is called before the first frame update
    void Start()
    {
        screenCentre = new Vector2(Screen.width / 2, Screen.height / 2);
    }

    // Update is called once per frame
    void Update()
    {
        imagePos = cam.WorldToScreenPoint(transform.position);
        if (imagePos.z < 0)
        {
            imagePos = new Vector3(-imagePos.x, -imagePos.y, 0);
        }
        float distance = Vector2.Distance(screenCentre, imagePos);

        if(distance >= circleRadius)
        {
            imagePos = screenCentre + circleRadius * (imagePos - screenCentre).normalized;
        }

        navigationItem.transform.position = imagePos;

        textItem.text = Vector3.Distance(transform.position, cam.transform.position).ToString("F2") + units;
    }
}
