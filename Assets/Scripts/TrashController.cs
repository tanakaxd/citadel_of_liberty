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

    private Vector3 hiddenOffset = new Vector3(1000, 0, 0);
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

                CardMovement card = e.pointerDrag.GetComponent<CardMovement>();
                if (card != null)
                {
                    //TODO この処理をhand側で行う？　例えばDiscardメソッドで
                    //hand.Discard(card,this)
                    card.parentAfterDrag = this.transform;
                    card.positionAfterDrag = this.transform.position + hiddenOffset;
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
