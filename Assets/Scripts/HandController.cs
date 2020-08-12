using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class HandController : MonoBehaviour
{
    public HandView view;
    public HandModel model;

    void Start()
    {
        model.cards.ObserveCountChanged()
            .DistinctUntilChanged()
            .Where(size=>size<=8)
            .Subscribe(size => view.handsTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, size*105));//CardWidth=100
    }

    public void AddCard(CardController card)
    {
        model.cards.Add(card);
        card.transform.SetParent(transform,false);
    }

    public void Discard()
    {

    }
}
