using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour //,IBeginDragHandler,IEndDragHandler,IDragHandler
{
    public static event Action PuzzleDone = delegate { };
  //  [SerializeField]
  //  private Canvas canvas; 
  //  private RectTransform rectTransform;
  //  private CanvasGroup canvasGroup;
    [SerializeField]
    private Transform standPosition;
    private Vector2 initialPosition;
    private Vector2 mousePosition;
    private float deltaX, deltaY;
    public static  bool locked;
    
    void Start()
    {  
        initialPosition = transform.position;
        locked = false;

    }

    /*  private void Awake()
      {
          canvasGroup = GetComponent<CanvasGroup>();
          rectTransform = GetComponent<RectTransform>();
      }

       public void OnBeginDrag(PointerEventData eventData)
       {

           transform.position = eventData.position;
           GetComponent<CanvasGroup>().blocksRaycasts = false;

       }

       public void OnDrag(PointerEventData eventData)
       {

           transform.position = eventData.position;
           rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
           Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);

       }

       public void OnEndDrag(PointerEventData eventData)
       {
           if (eventData.pointerCurrentRaycast.gameObject.name == "1")
           {
               transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;
               GetComponent<CanvasGroup>().blocksRaycasts = true;
           }


       }*/

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("aaa");
            deltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
            deltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;


        }
    }
   
    private void OnMouseDrag()
    {
        if (!locked)
        {
            Debug.Log("bbb");
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(mousePosition.x - deltaX, mousePosition.y - deltaY);
        }
    }
    private void OnMouseUp()
    {
        Debug.Log("ddd");
        if (Mathf.Abs(transform.position.x - standPosition.position.x) <= 1f && Mathf.Abs(transform.position.y - standPosition.position.y) <= 5f)
        {
            switch (PlanningManager.slotOccupoied)
            {
                case 0:
                    transform.position = new Vector2(transform.position.x, 114f);
                    PlanningManager.slotOccupoied = 1;
                    break;
                case 1:
                    transform.position = new Vector2(transform.position.x, 41f);
                    PlanningManager.slotOccupoied = 2;
                    break;
                case 2:
                    transform.position = new Vector2(transform.position.x, -26.5f);
                    PlanningManager.slotOccupoied = 3;
                    break;
                case 3:
                    transform.position = new Vector2(transform.position.x, -106f);
                    PlanningManager.slotOccupoied = 4;
                    break;
                case 4:
                    transform.position = new Vector2(transform.position.x, -180f);
                    PlanningManager.slotOccupoied = 5;
                    break;
                case 5:
                    transform.position = new Vector2(transform.position.x, -256f);
                    PuzzleDone();
                    break;
            }
            locked = true;
        }
        else
        {
            transform.position = new Vector2(initialPosition.x, initialPosition.y);
        }

    }



}
