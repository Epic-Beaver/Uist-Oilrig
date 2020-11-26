using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Scroller : MonoBehaviour, IBeginDragHandler, IEndDragHandler
{
    private ScrollRect scrollRect;
    public float[] pageArray = new float[] { 0, 0.25f, 0.5f, 0.75f, 1 };
    public float targetHorizontalPosition = 0;
    public bool isDraging = false;

    public static float speed = 6;

    public float horNormPos = 0;

    // Start is called before the first frame update
    void Start()
    {
        scrollRect = GetComponent<ScrollRect>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isDraging)
        {
            scrollRect.horizontalNormalizedPosition = Mathf.Lerp(scrollRect.horizontalNormalizedPosition, targetHorizontalPosition, Time.deltaTime * speed);
            //scrollRect.horizontalNormalizedPosition = 0.5f;
        }

        horNormPos = scrollRect.horizontalNormalizedPosition;
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isDraging = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDraging = false;
        float posX = scrollRect.horizontalNormalizedPosition;
        int index = 0;
        float offset = Mathf.Abs(pageArray[index] - posX);
        for (int i = 1; i < pageArray.Length; i++)
        {
            float offsetTemp = Mathf.Abs(pageArray[i] - posX);
            if(offsetTemp < offset)
            {
                offset = offsetTemp;
                index = i;
            }
        }

        targetHorizontalPosition = pageArray[index];
    }

    public void ClickBack ()
    {
        targetHorizontalPosition = 0;
    }

    public void ChangePage( int page)
    {
        targetHorizontalPosition = pageArray[page];
    }
}
