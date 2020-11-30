using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickRemove : MonoBehaviour
{
    public float speed;
    public Material highlightMat;

    public ClickRemove[] preRequisites;

    public string sectionName;

    public bool removed = false;

    public MouseOverText mouseOver;
    public bool hover;

    [TextArea]
    public string description;

    public FailureTab failTab;


    private Animator anim;

    private MeshRenderer[] childMeshes;
    private Material[] childMats;

    public GameObject removeEffect;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();

        childMeshes = GetComponentsInChildren<MeshRenderer>();
        childMats = new Material[childMeshes.Length];

        for(int i = 0; i < childMeshes.Length; i++)
        {
            childMats[i] = childMeshes[i].material;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (removed)
        {
            transform.position = transform.position + Vector3.up * speed;
        }
    }

    private void OnMouseEnter()
    {
        hover = true;
        mouseOver.updateInfo(name, this);
        mouseOver.updatePrerequisites(getRequirements(), preRequisites.Length);
        highlight();
    }

    private void highlight()
    {
        for(int i = 0; i < childMeshes.Length; i++)
        {
            childMeshes[i].material = highlightMat;
        }
    }

    private void OnMouseExit()
    {
        hover = false;
        unHighlight();
    }

    private void unHighlight()
    {
        for (int i = 0; i < childMeshes.Length; i++)
        {
            childMeshes[i].material = childMats[i];
        }
    }

    private void OnMouseDown()
    {
        foreach (ClickRemove pre in preRequisites)
        {
            if(!pre.removed)
            {
                //Cannot remove, inform player.
                OilRigComponentChecker.badTries++;
                failTab.fail(this);

                return;
            }
        }

        //anim.SetTrigger("Remove");
        removed = true;
        OilRigComponentChecker.timeToCheck = true;
        //GameObject.Instantiate(removeEffect, transform.position, transform.rotation);
    }

    public string getRequirements()
    {
        string requirements = "Prerequisites:\n";

        bool none = true;

        foreach (ClickRemove cr in preRequisites)
        {
            if (cr.removed)
            {
                requirements += "✓ " + cr.name + "\n";
            }
            else
            {
                requirements += "- " + cr.name + "\n";
            }
            none = false;
        }

        if (none)
        {
            requirements += "[None]";
        }

        return requirements;
    }
}
