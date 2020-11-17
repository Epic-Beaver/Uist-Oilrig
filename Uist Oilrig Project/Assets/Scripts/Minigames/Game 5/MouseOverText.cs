using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseOverText : MonoBehaviour
{
    public string information = "";

    private Image img;
    private Text uiText;
    private ClickRemove last;

    // Start is called before the first frame update
    void Start()
    {
        img = this.GetComponentInChildren<Image>();
        uiText = this.GetComponentInChildren<Text>();
        last = FindObjectOfType<ClickRemove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (last.hover == false)
        {
            img.enabled = false;
            information = "";
        } else
        {
            img.enabled = true;
        }

        uiText.text = information;
        transform.position = Input.mousePosition;
    }

    public void updateInfo(string information, ClickRemove last)
    {
        this.information = information;
        this.last = last;
    }
}
