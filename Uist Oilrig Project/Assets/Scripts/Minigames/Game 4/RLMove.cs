using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RLMove : MonoBehaviour
{
    public static RLMove instance;
    public GameObject right;
    public GameObject left;

    public float RLspeed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (ButtonRight.instance.isRight)
        {
            if(gameObject.transform.position.x > 1.3f)
            {
                if(UpDown.instance.transform.position.y < 2.84f)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * RLspeed);
                }
                
            }
            
        }
        if (ButtonLeft.instance.isLeft)
        {
            if(gameObject.transform.position.x < 1.9f)
            {
                if(UpDown.instance.transform.position.y < 2.84f)
                {
                    transform.Translate(Vector3.right * Time.deltaTime * RLspeed);
                }

            }
            
        }

        print(gameObject.transform.position);
    }
}
