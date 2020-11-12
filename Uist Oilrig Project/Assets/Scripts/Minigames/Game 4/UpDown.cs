using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDown : MonoBehaviour
{

    public static float moveSpeed = 0.06f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            if (transform.position.y < 3.4f)
            {
                transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);
            }
        }
        if (Input.GetAxisRaw("Vertical") < 0)
        {
            if(transform.position.y > 2.7f)
            {
                transform.Translate(Vector3.down * Time.deltaTime * moveSpeed);
            }
        }
    }
}
