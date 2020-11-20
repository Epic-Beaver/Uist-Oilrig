using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoTab : MonoBehaviour
{
    [TextArea]
    public string[] information;

    public string[] sceneNames;

    private Animator anim;

    public SimpleSceneManage sceneLoader;

    public Text textField;

    private int index = 0;

    private bool displaying = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Load into the currently selected scene
    public void begin()
    {
        if (index > 0)
        {
            sceneLoader.SceneByName(sceneNames[index]);
        }
    }

    public void updateInfoTab()
    {
        textField.text = information[index];
    }

    public void display(int index)
    {

        this.index = index;
        if (displaying)
        {
            anim.SetTrigger("Hide");
        }
        else
        {
            updateInfoTab();
        }

        displaying = true;
        anim.SetTrigger("Display");
    }

}
