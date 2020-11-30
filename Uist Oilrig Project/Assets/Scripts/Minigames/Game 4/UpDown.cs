using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDown : MonoBehaviour
{
    public static UpDown instance;

    public GameObject end;

    public static float moveSpeed = 0.06f;
    public bool liftUp = false;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        print(transform.position.y);
        if (ButtonUp.instance.isUp)
        {
            if (transform.position.y < 3.4f)
            {
                if(transform.position.y < 2.84f)
                {
                    liftUp = true;
                    transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);
                } else
                {
                    if (RLMove.instance.transform.position.x > 1.4f && RLMove.instance.transform.position.x < 1.6f)
                    {
                        liftUp = true;
                        transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);
                        RLMove.instance.right.SetActive(false);
                        RLMove.instance.left.SetActive(false);
                    } else
                    {
                        liftUp = false;
                    }
                }
                
            } else
            {
                end.SetActive(true);
                //Ending goes here.
            }
        }
        if (ButtonDown.instance.isDown)
        {
            if(transform.position.y > 2.7f)
            {
                transform.Translate(Vector3.down * Time.deltaTime * moveSpeed);
                if(transform.position.y < 2.84f)
                {
                    RLMove.instance.right.SetActive(true);
                    RLMove.instance.left.SetActive(true);
                }
            }
        }
    }

   
}
