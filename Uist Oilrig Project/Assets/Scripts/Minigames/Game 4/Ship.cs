using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public float moveSpeed = 3;
    public GameObject mainCamera;
    public GameObject cameraLeft;
    public GameObject cameraFront;
    public bool isBegin;
    public GameObject listPanel;
    public GameObject controller;

    // Start is called before the first frame update
    void Start()
    {
        controller.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isBegin)
        {
            if (transform.position.x > 1)
            {
                gameObject.transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);
            }
            else
            {

                mainCamera.SetActive(false);
                cameraLeft.SetActive(true);
                controller.SetActive(true);
            }

        }

    }

    public void StartMove()
    {
        isBegin = true;
        listPanel.SetActive(false);
    }
}
