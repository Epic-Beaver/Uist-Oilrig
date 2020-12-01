using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RLMove : MonoBehaviour
{
    public static RLMove instance;

    public GameObject right;
    public GameObject left;
    public AudioSource verticalMoveAudio;
    public AudioSource horizontalMoveAudio;

    public float RLspeed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        verticalMoveAudio = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //print(verticalMoveAudio.isPlaying);
        if (ButtonRight.instance.isRight)
        {
            if(gameObject.transform.position.x > 1.3f)
            {
                if(UpDown.instance.transform.position.y < 2.84f)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * RLspeed);
                    verticalMoveAudio.pitch = 1;
                    if (!verticalMoveAudio.isPlaying)
                        verticalMoveAudio.Play();
                }
                else
                {
                    if (verticalMoveAudio.isPlaying)
                        verticalMoveAudio.Stop();
                }

            } else
            {
                if (verticalMoveAudio.isPlaying)
                    verticalMoveAudio.Stop();
            }

            
        }else if (ButtonLeft.instance.isLeft)
        {
            if(gameObject.transform.position.x < 1.9f)
            {
                if(UpDown.instance.transform.position.y < 2.84f)
                {
                    transform.Translate(Vector3.right * Time.deltaTime * RLspeed);
                    verticalMoveAudio.pitch = 1;
                    if (!verticalMoveAudio.isPlaying)
                        verticalMoveAudio.Play();
                }
                else
                {
                    if (verticalMoveAudio.isPlaying)
                        verticalMoveAudio.Stop();
                }

            }
            else
            {
                if (verticalMoveAudio.isPlaying)
                    verticalMoveAudio.Stop();
            }

        } else
        {
            if (verticalMoveAudio.isPlaying)
                verticalMoveAudio.Stop();
        }

        //print(gameObject.transform.position);
    }
}
