using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class ManaController : MonoBehaviour
{
    public ManaModel model;
    public ManaView view;

    private Vector3 hiddenOffset = new Vector3(1000, 0, 0);

    public HandController hand;
    void Start()
    {
        model.greenMana.DistinctUntilChanged()
            .SubscribeToText(view.greenMana);
        model.blueMana.DistinctUntilChanged()
            .SubscribeToText(view.blueMana);
        model.redMana.DistinctUntilChanged()
            .SubscribeToText(view.redMana);

        var trigger = gameObject.AddComponent<ObservableEventTrigger>();

        trigger.OnDropAsObservable()
            .Where(_ => !GameManager.Instance.isChoicePrompting)
            //.Where(e=> e.pointerDrag.GetComponent<CardSpellController>()!=null)
            .Do(_ => Debug.Log("OnDropMana"))
            .Subscribe(e=> {
                CardMovement cardToPlay = e.pointerDrag.GetComponent<CardMovement>();
                if (cardToPlay == null) return;
                cardToPlay.parentAfterDrag = this.transform;
                cardToPlay.positionAfterDrag = transform.position + hiddenOffset;

                CardSpellController spellCard = e.pointerDrag.GetComponent<CardSpellController>();
                if (spellCard == null) return;

                hand.Play(spellCard);

                //ここでdestoryするとenddragが発動しない
            });
    }


}
