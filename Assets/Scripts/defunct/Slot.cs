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
            card.parentAfterDrag=this.transform;
            card.positionAfterDrag = this.transform.position;
        }

    }
}
