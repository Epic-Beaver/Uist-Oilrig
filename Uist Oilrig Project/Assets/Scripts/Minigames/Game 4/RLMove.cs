using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RLMove : MonoBehaviour
{
    public float RLspeed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.Translate(Vector3.left * Time.deltaTime * RLspeed);
        }
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.Translate(Vector3.right * Time.deltaTime * RLspeed);
        }
    }
}
