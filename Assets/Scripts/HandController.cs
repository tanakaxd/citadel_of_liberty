using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class HandController : MonoBehaviour
{
    public HandView view;
    public HandModel model;

    public TrashController trash;

    void Start()
    {
        model.cards.ObserveCountChanged()
            .DistinctUntilChanged()
            .Where(size => size <= 8)
            .Subscribe(size => { 
                view.handsTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, size * 105);//CardWidth=100
                view.counter.text = size.ToString();
            }) ;
    }

    public void AddCard(CardController card)
    {
        model.cards.Add(card);
        card.transform.SetParent(transform,false);
    }

    public void Discard()
    {

    }

    public void Build(CardController card)
    {
        Debug.Log(model.cards.Remove(card));
    }

    public void Play()
    {

    }
}
