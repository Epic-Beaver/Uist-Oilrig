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
        mesh.material = highlightMat;

        //MouseOverText
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

                return;
            }
        }

        anim.SetTrigger("Remove");
        removed = true;
    }
}
