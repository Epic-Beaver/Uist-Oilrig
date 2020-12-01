using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FontColorChange : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text text;

    private float r;
    private float g;
    private float b;
    // Start is called before the first frame update
    void Start()
    {
        r = this.GetComponent<Image>().color.r;
        g = this.GetComponent<Image>().color.g;
        b = this.GetComponent<Image>().color.b;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AnswerRight()
    {
        text.color = new Color(0, 180f / 255f, 0);
    }

    public void AnswerWrong()
    {
        text.color = Color.red;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        this.GetComponent<Image>().color = new Color(r, g, b, 1);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.GetComponent<Image>().color = new Color(r, g, b, 0);
    }
}
