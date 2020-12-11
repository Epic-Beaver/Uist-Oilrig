using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleRandomiser : MonoBehaviour
{

    public Vector3 startAngle;
    public Vector3 endAngle;

    public bool randomPCT;

    public float pct;

    // Start is called before the first frame update
    void Start()
    {
        if (randomPCT)
        {
            pct = Random.Range(0f, 1f);
        }

        transform.rotation = Quaternion.Euler(Vector3.Lerp(startAngle, endAngle, pct));
    }
}
