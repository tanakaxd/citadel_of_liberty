using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine.EventSystems;

public class SlotController : MonoBehaviour
{
    public List<SlotController> linkedSlots = new List<SlotController>();
    public CardController building;

    public TrashController trash;

    private void Awake()
    {
        GetBuilding();
    }

    void Start()
    {

        gameObject.AddComponent<ObservableEventTrigger>().OnDropAsObservable()
            .Where(_=>GameManager.Instance.isBuilding)
            .Do(_=>Debug.Log("OnDropAsObservable Onnext"))
            .Do(e=>Debug.Log(e.pointerDrag))
            .Subscribe(e => OnDrop(e));
    }

    public void OnDrop(PointerEventData eventData)//OnEndDragより先に起きる
    {
        Debug.Log("OnDrop");

        CardBuilt card = eventData.pointerDrag.GetComponent<CardBuilt>();
        if (card != null)
        {
            card.parentBeforeDrag = this.transform;
            card.positionAfter = this.transform.position;
            this.building = card.GetComponent<CardController>();
            GameManager.Instance.isBuilding = false;
            Debug.Log("GetBuilding: " + this.building);
        }
    }

    
    private void GetBuilding()//初期化用
    {
        this.building = transform.GetComponentInChildren<CardController>();
        Debug.Log("GetBuilding: " + this.building);
    }

    public void DemolishBuilding()
    {
        trash.AddCard(this.building);
        this.building = null;
    }

}
