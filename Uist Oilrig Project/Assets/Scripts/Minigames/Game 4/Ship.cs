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
    public AudioSource shipAudio;

    // Start is called before the first frame update
    void Start()
    {
        controller.SetActive(false);
        shipAudio = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isBegin)
        {
            if (transform.position.x > 1)
            {
                gameObject.transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);
                shipAudio.pitch = 1;
                //shipAudio.volume = 0.5f;
                if (!shipAudio.isPlaying)
                    shipAudio.Play();
            }
            else
            {

                mainCamera.SetActive(false);
                cameraLeft.SetActive(true);
                controller.SetActive(true);
                if (shipAudio.isPlaying)
                    shipAudio.Stop();
            }

        }

    }

    public void StartMove()
    {
        isBegin = true;
        listPanel.SetActive(false);
    }
}
