using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonDown : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler, IPointerEnterHandler
{
    public static ButtonDown instance;

    public bool isDown;

    private float alpha;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        alpha = gameObject.GetComponent<Image>().color.a;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        gameObject.GetComponent<Image>().color = new Color(140f / 255f, 140f / 255f, 140f / 255f, alpha);
        isDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        gameObject.GetComponent<Image>().color = new Color(168f / 255f, 168f / 255f, 168f / 255f, alpha);
        isDown = false;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.GetComponent<Image>().color = new Color(255, 255, 255, alpha);
        isDown = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.GetComponent<Image>().color = new Color(168f / 255f, 168f / 255f, 168f / 255f, alpha);
    }
}
