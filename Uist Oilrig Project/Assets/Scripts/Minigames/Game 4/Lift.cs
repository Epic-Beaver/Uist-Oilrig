using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{
    public GameObject platform;

    private float moveSpeed;
    private int isCollid;
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = UpDown.moveSpeed;
        isCollid = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCollid == 1)
        {
            platform.transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);
        }
        if (ButtonDown.instance.isDown)
        {
            if (platform.transform.position.y > 4.64f)
            {
                platform.transform.Translate(Vector3.down * Time.deltaTime * moveSpeed);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //print(transform.position.y);
        if (ButtonUp.instance.isUp)
        {
            isCollid = 1;
            //if (transform.position.y < 3.4f)
            //{
            //    transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);
            //}
        }

    }
    private void OnCollisionExit(Collision collision)
    {
        //print("finish");
        isCollid = 0;
    }
}
