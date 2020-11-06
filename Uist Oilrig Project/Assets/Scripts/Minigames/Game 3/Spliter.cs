using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;
public class Spliter : MonoBehaviour
{
    public Material matCross;
    void Start()
    {
        
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Collider[] colliders = Physics.OverlapBox(transform.position, new Vector3(0.5f, 0.005f, 0.5f),transform.rotation,~LayerMask.GetMask("solid","drill"));
            foreach (Collider c in colliders)
            {
                Destroy(c.gameObject);
                //GameObject[] objs = c.gameObject.SliceInstantiate(transform.position, transform.up);
                SlicedHull hull = c.gameObject.Slice(transform.position, transform.up);
                if (hull != null)
                {
                    GameObject lower = hull.CreateLowerHull(c.gameObject, matCross);
                    GameObject upper = hull.CreateLowerHull(c.gameObject, matCross);
                    GameObject[] objs = new GameObject[] { lower, upper };
                    foreach (GameObject obj in objs)
                    {
                        Rigidbody rb= obj.AddComponent<Rigidbody>();
                        obj.AddComponent<MeshCollider>().convex = true;
                        rb.AddExplosionForce(1, c.gameObject.transform.position, 1);
                    }
                }
                
            }
        }
    }
}
