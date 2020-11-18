using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    [SerializeField]
    private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    [SerializeField]
    private static Transform correctTrans;

    //public static Vector2 initialPosition;


    //void Start()
    //{  
    //    initialPosition = rectTransform.anchoredPosition;

    //}

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {

        // transform.position = eventData.position;
        GetComponent<CanvasGroup>().blocksRaycasts = false;

    }

    public void OnDrag(PointerEventData eventData)
    {

        transform.position = eventData.position;
        rectTransform.anchoredPosition += eventData.delta/ canvas.scaleFactor;
     //   Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);
      //  Debug.Log(eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition);

    }

    public void OnEndDrag(PointerEventData eventData)
    {

        //      transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;
        GetComponent<CanvasGroup>().blocksRaycasts = true;



    }
}
