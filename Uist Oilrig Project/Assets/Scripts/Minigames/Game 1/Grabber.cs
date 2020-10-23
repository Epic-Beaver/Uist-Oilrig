using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DistanceJoint2D))]
public class Grabber : MonoBehaviour
{
    DistanceJoint2D joint;

    public float depth;
    public bool grabbable = true;

    float maxHeight;
    float minHeight;
    public float grabDistance;
    int time = 0;
    int maxTime = 300;
    private AudioSource audioSource;
    public int co2Time = 0;

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
        if (Input.GetAxisRaw("Fire1") > 0 && grabbable)
        {
            time++;
            audioSource.pitch = 1.0f;
            if (!audioSource.isPlaying)
                audioSource.Play();
            co2Time++;
        } else
        {
            time--;
            co2Time++;
        }

        //Time is bounded by 0 and maxTime.
        if (time < 0)
        {
            grabbable = true;
            time = 0;
            audioSource.Stop();
        }
        if (time > maxTime)
        {
            time = maxTime;
        }

        float height = maxHeight - ((float)time / maxTime) * maxHeight;

        transform.position = new Vector3(transform.position.x, height, transform.position.z);

        if (Input.GetAxisRaw("Fire2") > 0)
        {
            grabbable = false;
            joint.connectedBody = null;

        }
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
            joint.distance = Vector3.Distance(transform.position, collision.transform.position);
            grabbable = false;
        }
    }
}
