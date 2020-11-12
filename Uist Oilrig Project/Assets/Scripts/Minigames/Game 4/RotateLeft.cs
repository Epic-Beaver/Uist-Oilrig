using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLeft : MonoBehaviour
{
    public float rotateSpeed = 8;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Vertical") < 0)
        {
            if(transform.rotation.x > -0.2)
            {
                transform.Rotate(-rotateSpeed * Time.deltaTime, transform.rotation.y, transform.rotation.z);
            }
        }
            
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            if (transform.rotation.x < 0.3f)
            {
                transform.Rotate(rotateSpeed * Time.deltaTime, transform.rotation.y, transform.rotation.z);
            }
            
        }
    }
}
