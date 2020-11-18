using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShake : MonoBehaviour
{
    //public Vector3 objectPos;

    //public Vector3 strength;
    //private Vector3 strengthDefault;

    //public float shakeTime = 1f;
    //private float shakeTimeDefault;

    //public float decay = 0.8f;

    //public bool isShaking = false;

    //private void Start()
    //{
    //    objectPos = transform.position;
    //    strengthDefault = strength;
    //    shakeTimeDefault = shakeTime;
    //}
    //private void Update()
    //{
    //    if (isShaking)
    //    {
    //        if (shakeTime > 0)
    //        {
    //            shakeTime -= Time.deltaTime;
    //            Vector3 temPos = transform.position;
    //            temPos.x = objectPos.x + Random.Range(-strength.x, strength.x);
    //            temPos.y = objectPos.y + Random.Range(-strength.y, strength.y);
    //            temPos.z = objectPos.z + Random.Range(-strength.z, strength.z);
    //            transform.position = temPos;
    //            strength *= decay;
    //        }
    //        else
    //        {
    //            shakeTime = 0;
    //            transform.position = objectPos;
    //            isShaking = false;
    //            strength = strengthDefault;
    //            shakeTime = shakeTimeDefault;
    //        }
    //    }
    //}
    //public void StartShake()
    //{
    //    isShaking = true;
    //    strength = strengthDefault;
    //    shakeTime = shakeTimeDefault;
    //}

    public Animator camAnim;
    public void camshake()
    {
        camAnim.SetTrigger("shake");
    }
    
    
}
