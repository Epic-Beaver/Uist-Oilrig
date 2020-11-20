using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickRemove : MonoBehaviour
{
    public Material regularMat;
    public Material highlightMat;

    public ClickRemove[] preRequisites;

    public string sectionName;

    public bool removed = false;

    public MouseOverText mouseOver;
    public bool hover;

    [TextArea]
    public string description;

    public FailureTab failTab;

    private MeshRenderer mesh;

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        mesh = this.GetComponent<MeshRenderer>();
        anim = this.GetComponent<Animator>();

        mesh.material = regularMat;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        hover = true;
        mouseOver.updateInfo(name, this);
        mouseOver.updatePrerequisites(getRequirements(), preRequisites.Length);
        mesh.material = highlightMat;
    }

    private void OnMouseExit()
    {
        hover = false;
        mesh.material = regularMat;
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

        anim.SetTrigger("Remove");
        removed = true;
        OilRigComponentChecker.timeToCheck = true;
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
