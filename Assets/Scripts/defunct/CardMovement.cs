using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardMovement : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Canvas canvas;
    private CanvasGroup canvasGroup;
    [HideInInspector]public Transform parentBeforeDrag;
    [HideInInspector] public Vector3 positionAfter;
    private Vector3 offset;
    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = FindObjectOfType<Canvas>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if(!GameManager.Instance.isDiscarding && !GameManager.Instance.isBuilding)
        {
            return;
        }

        Debug.Log("begindrag");
        canvasGroup.blocksRaycasts = false;
        positionAfter = transform.position;

        parentBeforeDrag = transform.parent;
        transform.SetParent(canvas.transform,false);

        canvasGroup.alpha = 0.5f;
        //offset = ;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!GameManager.Instance.isDiscarding && !GameManager.Instance.isBuilding)
        {
            return;
        }
        //Debug.Log("drag");

        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!GameManager.Instance.isDiscarding && !GameManager.Instance.isBuilding)
        {
            return;
        }
        Debug.Log("enddrag");
        //pointerDragはドラッグされているオブジェクト

        //SlotならparentBeforeDragとpositionAfterが書き換えられる
        transform.SetParent(parentBeforeDrag,false);
        transform.position = positionAfter;

        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1.0f;
    }
}
