using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ParentBeneath : MonoBehaviour
{
    public LayerMask layerMask;
    public float distance;
    public UnityEvent countUp;
    public UnityEvent countDown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D result = new RaycastHit2D();

        result = Physics2D.Raycast(transform.position, Vector2.down, distance, layerMask);

        if(result)
        {
            transform.SetParent(result.collider.transform);
        }
        else
        {
            transform.SetParent(null);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Vessel"))
        {
            countUp.Invoke();
            Debug.Log("Ahoy?");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Vessel"))
        {
            countDown.Invoke();
            Debug.Log("Goodbye?");
        }
    }
}
