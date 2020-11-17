using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Back : MonoBehaviour
{
    public Image image;

    private ScrollRect scrollRect;
    private float speed;
    private float originalPosition;
    private bool isClick;
    // Start is called before the first frame update
    void Start()
    {
        scrollRect = image.GetComponent<ScrollRect>();
        speed = Scroller.speed;
        originalPosition = scrollRect.horizontalNormalizedPosition;
        isClick = false;
    }

    // Update is called once per frame
    void Update()
    {
        print(scrollRect.horizontalNormalizedPosition);
        if (isClick)
        {
            scrollRect.horizontalNormalizedPosition = Mathf.Lerp(scrollRect.horizontalNormalizedPosition, originalPosition, Time.deltaTime * speed);
        }
        if (scrollRect.horizontalNormalizedPosition == originalPosition)
        {
            isClick = false;
        }
    }

    public void Click()
    {
        isClick = true;
    }
}
