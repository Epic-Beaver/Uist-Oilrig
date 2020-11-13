using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanSway : MonoBehaviour
{

    public float horStrength;
    public float vertStrength;
    public int period;

    private int waveTime = 0;
    private Vector3 origin = new Vector3();

    // Start is called before the first frame update
    void Start()
    {
        origin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        waveTime++;

        if (waveTime >= period)
        {
            waveTime = 0;
        }

        Vector3 offset = new Vector3();

        float pct = Mathf.PI * 2 * ((float)waveTime / period);

        offset = new Vector3(Mathf.Cos(pct) * horStrength, Mathf.Sin(pct) * vertStrength, 0);

        transform.position = origin + offset;
    }
}
