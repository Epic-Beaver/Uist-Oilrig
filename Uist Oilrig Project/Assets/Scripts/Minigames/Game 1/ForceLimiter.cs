using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ForceLimiter : MonoBehaviour
{

    public float forceLimit;
    public UnityEvent regCollision;
    public UnityEvent vesselCollision;
    public int gracePeriod = 60;
    private int graceTimer = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(graceTimer < gracePeriod)
        {
            graceTimer++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > forceLimit && graceTimer >= gracePeriod)
        {
            if (collision.collider.CompareTag("Vessel"))
            {
                vesselCollision.Invoke();
                Debug.Log("Boaty mcBrokeFace");
            }
            else
            {
                regCollision.Invoke();
                Debug.Log("Too Fast, too furious");
            }
        }
    }
}
