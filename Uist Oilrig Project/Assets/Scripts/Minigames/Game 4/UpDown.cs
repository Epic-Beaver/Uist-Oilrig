using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDown : MonoBehaviour
{
    public static UpDown instance;

    public GameObject end;

    public static float moveSpeed = 0.06f;
    public bool liftUp = false;

    private AudioSource moveAudio;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        moveAudio = GameObject.Find("LiftAudio").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //print(transform.position.y);
        if (ButtonUp.instance.isUp)
        {
            if (transform.position.y < 3.4f)
            {
                if(transform.position.y < 2.84f)
                {
                    liftUp = true;
                    transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);
                    moveAudio.pitch = 1;
                    if (!moveAudio.isPlaying)
                        moveAudio.Play();
                } else
                {
                    if (RLMove.instance.transform.position.x > 1.4f && RLMove.instance.transform.position.x < 1.6f)
                    {
                        liftUp = true;
                        transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);
                        moveAudio.pitch = 1;
                        if (!moveAudio.isPlaying)
                            moveAudio.Play();
                        RLMove.instance.right.SetActive(true);
                        RLMove.instance.left.SetActive(true);
                    } else
                    {
                        liftUp = false;
                        if (moveAudio.isPlaying)
                            moveAudio.Stop();
                    }
                }
                
            } else
            {
                if (moveAudio.isPlaying)
                    moveAudio.Stop();
                
                
                end.SetActive(true);
                //Ending goes here.
            }
        }else if (ButtonDown.instance.isDown)
        {
            if(transform.position.y > 2.7f)
            {
                transform.Translate(Vector3.down * Time.deltaTime * moveSpeed);
                moveAudio.pitch = 1;
                if (!moveAudio.isPlaying)
                    moveAudio.Play();
                if (transform.position.y < 2.84f)
                {
                    RLMove.instance.right.SetActive(false);
                    RLMove.instance.left.SetActive(false);
                }
            }
            else
            {
                if (moveAudio.isPlaying)
                    moveAudio.Stop();
            }
        } else
        {
            if (moveAudio.isPlaying)
                moveAudio.Stop();
        }
    }

   
}
