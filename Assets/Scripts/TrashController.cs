using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class TrashController : MonoBehaviour
{
    public TrashModel model;
    public TrashView view;
    void Start()
    {
        model.cards.ObserveCountChanged().DistinctUntilChanged().SubscribeToText(view.trashCounter);
    }

    public void AddCard(CardController card)
    {
        model.cards.Add(card);
    }

}
