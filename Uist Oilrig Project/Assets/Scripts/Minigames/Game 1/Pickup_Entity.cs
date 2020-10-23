using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Entity : MonoBehaviour
{

    DistanceJoint2D joint;

    public float leftX;
    public float rightX;

    private float slopeCalc;

    public float maxHorSpeed;
    public float maxVertSpeed;

    public GameObject Claw;
    private AudioSource audioSource;
    public int co2Time = 0;

    // Start is called before the first frame update
    void Start()
    {
        joint = this.GetComponentInChildren<DistanceJoint2D>();
        slopeCalc = (rightX - leftX) / (Screen.width);
        audioSource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 targetPos = Input.mousePosition;
        float targetX = leftX + slopeCalc * (targetPos.x - 0);

        if(targetX - transform.position.x > maxHorSpeed)
        {
            targetX = transform.position.x + maxHorSpeed;
            co2Time++;
         }
        else if (targetX - transform.position.x < -maxHorSpeed)
        {
            targetX = transform.position.x - maxHorSpeed;
            co2Time++;

        }
        audioSource.pitch = 1.0f;
        if (!audioSource.isPlaying)
            audioSource.Play();

        transform.position = new Vector3(targetX, transform.position.y, transform.position.z);
    }
}
