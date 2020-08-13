using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class HandController : MonoBehaviour
{
    public HandView view;
    public HandModel model;

    public int discardCounter = 0;
    private CardController cardToBuild;

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

    //ScriptableObjectではStartCoroutineが使えないのでラッパーメソッド
    public void StartDiscard()
    {
        StartCoroutine(DiscardCoroutine());
    }

    public IEnumerator DiscardCoroutine()
    {
        //コスト分のカードが捨てられるまで
        yield return new WaitUntil(()=>this.discardCounter==cardToBuild.model.discardsToBuild.Value);

        this.cardToBuild = null;
        this.discardCounter = 0;
        GameManager.Instance.isDiscarding = false;

    }

    public void Build(CardController card)//手札から建設したとき、ボード側から呼び出される
    {
        cardToBuild = card;
        model.cards.Remove(card);
    }

    public void Play(CardController card)//手札からプレイしたとき、ボード側から呼び出される
    {
        card.Play();
        model.cards.Remove(card);
    }

    public void DiscardForCosts(CardController card)
    {
        model.cards.Remove(card);
        this.discardCounter++;
    }

    public void DiscardAll()
    {

    }
}
