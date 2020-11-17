using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseOverText : MonoBehaviour
{
    public string information = "";
    [TextArea]
    public string requirements = "";

    public int height;
    private float defHeight;
    public float deltaHeight = 15;

    private Image img;
    private Text uiText;
    private ClickRemove last;

    // Start is called before the first frame update
    void Start()
    {
        img = this.GetComponentInChildren<Image>();
        uiText = this.GetComponentInChildren<Text>();
        last = FindObjectOfType<ClickRemove>();
        defHeight = img.rectTransform.sizeDelta.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (last.hover == false)
        {
            img.enabled = false;
            information = "";
            requirements = "";
        } else
        {
            img.enabled = true;
            img.rectTransform.sizeDelta = new Vector2(img.rectTransform.sizeDelta.x, defHeight + (deltaHeight * height));
            Debug.Log("Updating");
        }

        uiText.text = information + "\n\n" + requirements;
        transform.position = Input.mousePosition;
    }

    public void updateInfo(string information, ClickRemove last)
    {
        this.information = information;
        this.last = last;
    }

    public void updatePrerequisites(string requirements, int height)
    {
        this.requirements = requirements;
        this.height = height;
    }
}
