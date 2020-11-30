using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotateSpeed = 8;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ButtonUp.instance.isUp)
        {
            if(UpDown.instance.liftUp)
            {
                if (transform.rotation.x > -0.4f)
                {
                    transform.Rotate(-rotateSpeed * Time.deltaTime, transform.rotation.y, transform.rotation.z);
                }
            }
            
            
        }
        if (ButtonDown.instance.isDown)
        {
            if (transform.rotation.x < 0.35f)
            {
                transform.Rotate(rotateSpeed * Time.deltaTime, transform.rotation.y, transform.rotation.z);
            }
            
        }
    }
}
