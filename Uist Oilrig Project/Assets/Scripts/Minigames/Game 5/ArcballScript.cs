using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class ArcballScript : MonoBehaviour
{

    public float rotationSpeed = 1f;
    public float radius = 5f;
    public float haloHeight = 0.8f;
    public float drag = 0.05f;

    public float momentum = 0;

    public float maxVelocity;

    // The mouse cursor's position during the last frame
    Vector3 last = new Vector3();

    // The target that the camera looks at
    public Vector3 target;

    // The spherical coordinates
    Vector3 sc = new Vector3();

    void Start()
    {
        this.transform.position = new Vector3(radius, 0.0f, 0.0f);
        this.transform.LookAt(target);
        sc = getSphericalCoordinates(this.transform.position);
    }

    Vector3 getSphericalCoordinates(Vector3 cartesian)
    {
        float r = Mathf.Sqrt(
            Mathf.Pow(cartesian.x, 2) +
            Mathf.Pow(cartesian.y, 2) +
            Mathf.Pow(cartesian.z, 2)
        );

        float phi = Mathf.Atan2(cartesian.z / cartesian.x, cartesian.x);
        float theta = Mathf.Acos(cartesian.y / r);

        if (cartesian.x < 0)
            phi += Mathf.PI;

        return new Vector3(r, phi, theta);
    }

    Vector3 getCartesianCoordinates(Vector3 spherical)
    {
        Vector3 ret = new Vector3();

        ret.x = spherical.x * Mathf.Cos(spherical.z) * Mathf.Cos(spherical.y);
        ret.y = spherical.x * Mathf.Sin(spherical.z);
        ret.z = spherical.x * Mathf.Cos(spherical.z) * Mathf.Sin(spherical.y);

        return ret;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            last = Input.mousePosition;
        }
        else if (Input.GetMouseButton(1))
        {
            momentum = (last.x - Input.mousePosition.x);
        }

            if (momentum < drag && momentum > (-1*drag)) 
        {
            momentum = 0;
        } 
        else if(momentum > 0)
        {
            momentum -= drag;
        }else if(momentum < 0)
        {
            momentum += drag;
        }

        moveCamera();
    }

    void moveCamera()
    {
        float dx = momentum * rotationSpeed;
        if (dx != 0f)
        {
            sc.y += dx * Time.deltaTime;

            sc.z = haloHeight;

            // Calculate the cartesian coordinates for unity
            transform.position = getCartesianCoordinates(sc) + target;

            // Make the camera look at the target
            transform.LookAt(target);
        }

        // Update the last mouse position
        last = Input.mousePosition;
    }
}