using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BlockJoint : MonoBehaviour
{

    public GameObject jointParent;

    private JointMotor joint;
    Vector3 parentPos;
    Vector3 parentRot;
    // Start is called before the first frame update
    void Start()
    {
        
        joint.force = 10;
        parentPos = jointParent.transform.localPosition;
        parentRot = jointParent.transform.localEulerAngles;
    }

    // Update is called once per frame
    void Update()
    {

        jointParent.transform.localPosition = parentPos; 
        jointParent.transform.localEulerAngles = parentRot;

        if(Input.GetAxisRaw("Vertical") > 0)
        {
            joint.targetVelocity = -20;
        }
        else if (Input.GetAxisRaw("Vertical") < 0)
        {
            joint.targetVelocity = 20;
        } else
        {
            joint.targetVelocity = 0;
        }
        gameObject.GetComponent<HingeJoint>().motor = joint;
    }
}
