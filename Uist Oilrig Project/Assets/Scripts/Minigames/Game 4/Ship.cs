﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public float moveSpeed = 3;
    public GameObject mainCamera;
    public GameObject cameraLeft;
    public GameObject cameraFront;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 1)
        {
            gameObject.transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);
        } else
        {

            mainCamera.SetActive(false);
            cameraLeft.SetActive(true);
        }
            
    }
}