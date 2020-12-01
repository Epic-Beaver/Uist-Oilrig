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
    public PlanningManager1 planningManager;
   
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
        for(int i = 0; i < 6; i++)
        {
            if(planningManager.options[i].position.x!= planningManager.box[i].transform.position.x)
            {
                planningManager.options[i].position = planningManager.initialPosition [i].position;
                
            }
        }
        //      transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;
        GetComponent<CanvasGroup>().blocksRaycasts = true;



    }
}
