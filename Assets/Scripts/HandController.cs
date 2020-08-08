using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class HandController : MonoBehaviour
{
    private ReactiveCollection<CardController> cards = new ReactiveCollection<CardController>();
    public HandView view;
    public HandModel model;

    void Start()
    {
        cards.ObserveCountChanged()
            .DistinctUntilChanged()
            .Where(size=>size<=8)
            .Subscribe(size => view.handsTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, size*105));//CardWidth=100
    }

    void Update()
    {
        
    }

    public void AddCard(CardController card)
    {
        cards.Add(card);
        card.transform.SetParent(transform);
    }
}
