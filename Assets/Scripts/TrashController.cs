using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class TrashController : MonoBehaviour
{
    public TrashModel model;
    public TrashView view;

    public HandController hand;

    void Start()
    {
        model.cards.ObserveCountChanged()
            .DistinctUntilChanged()
            .SubscribeToText(view.trashCounter);

      
        var trigger = gameObject.AddComponent<ObservableEventTrigger>();

        trigger.OnDropAsObservable()
            .Where(_ => GameManager.Instance.isDiscarding)
            .Subscribe(e =>
            {
                Debug.Log("Trash OnDrop");

                //TODO CardBuiltではなく専用のクラスを作る
                CardBuilt card = e.pointerDrag.GetComponent<CardBuilt>();
                if (card != null)
                {
                    //TODO この処理をhand側で行う？　例えばDiscardメソッドで
                    //hand.Discard(card,this)
                    card.parentBeforeDrag = this.transform;
                    card.positionAfter = this.transform.position;
                    CardController discardedCard = card.GetComponent<CardController>();
                    model.cards.Add(discardedCard);
                    hand.DiscardForCosts(discardedCard);
                }
            });


    }

    public void AddCard(CardController card)
    {
        model.cards.Add(card);
    }

}
