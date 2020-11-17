using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FailureTab : MonoBehaviour
{
    public string title;
    public string information;

    public Text moduleName;
    public Text description;

    private Animator anim;

    private bool displaying = false;

    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    public void fail(ClickRemove click)
    {
        title = click.name;
        information = click.description;

        information += "\n" + click.getRequirements();

        if (displaying)
        {
            anim.SetTrigger("Hide");
        }
        else
        {
            updateInfo();
        }

        displaying = true;

        anim.SetTrigger("Display");
    }

    public void hideDisplay()
    {
        displaying = false;
        anim.SetTrigger("Hide");
    }

    public void updateInfo()
    {
        moduleName.text = title;
        description.text = information;
        Debug.Log("Updated");
    }
}
