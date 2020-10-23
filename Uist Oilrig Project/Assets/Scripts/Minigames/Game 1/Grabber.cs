using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DistanceJoint2D))]
public class Grabber : MonoBehaviour
{
    DistanceJoint2D joint;

    public float depth;

    float maxHeight;
    float minHeight;
    public float grabDistance;
    int time = 0;
    int maxTime = 300;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        joint = this.GetComponent<DistanceJoint2D>();

        maxHeight = transform.position.y;
        minHeight = transform.position.y - depth;
        audioSource = this.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetAxisRaw("Fire1") > 0)
        {
            time++;
            audioSource.pitch = 1.0f;
            if (!audioSource.isPlaying)
                audioSource.Play();
        } else
        {
            time--;
        }

        //Time is bounded by 0 and maxTime.
        if (time < 0)
        {
            time = 0;
            audioSource.Stop();
        }
        if (time > maxTime)
        {
            time = maxTime;
        }

        float height = maxHeight - ((float)time / maxTime) * maxHeight;

        transform.position = new Vector3(transform.position.x, height, transform.position.z);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Trigger")
        {
            joint.connectedBody = null;
        }
        if (collision.GetComponent<Rigidbody2D>())
        {
            joint.connectedBody = collision.GetComponent<Rigidbody2D>();
            Debug.Log("Done it");
        }
    }
}
