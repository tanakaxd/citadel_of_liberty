using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)//OnEndDragより先に起きる
    {
        Debug.Log("OnDrop");

        CardMovement card = eventData.pointerDrag.GetComponent<CardMovement>();
        if (card != null)
        {
            card.parentBeforeDrag=this.transform;
            card.positionAfter = this.transform.position;
        }

    }
}
