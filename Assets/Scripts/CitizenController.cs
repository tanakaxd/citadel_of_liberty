using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;
using static CardData;

public class CitizenController : MonoBehaviour
{
    public CitizenView view;


    public ReactiveProperty<CitizenType> type = new ReactiveProperty<CitizenType>();
    public CardCategory favorite;

    public ManaController mana;
    void Start()
    {
        type.SubscribeToText(view.text);

        //TODO mouseOverされたとき
    }

    public void Init()
    {
        List<CitizenType> types = Enum.GetValues(typeof(CitizenType)).Cast<CitizenType>().ToList();
        type.Value = types[UnityEngine.Random.Range(0, types.Count)];

        List<CardCategory> cardCategories =  Enum.GetValues(typeof(CardCategory)).Cast<CardCategory>().ToList();
        favorite = cardCategories[UnityEngine.Random.Range(0, cardCategories.Count)];

    }

    public void Init(CitizenType color)
    {

    }

    public void ProduceMana()
    {
        switch (type.Value)
        {
            case CitizenType.GREEN:
                mana.model.greenMana.Value++;
                break;
            case CitizenType.BLUE:
                mana.model.blueMana.Value++;
                break;
            case CitizenType.RED:
                mana.model.redMana.Value++;
                break;
            default:
                Debug.Log("invalid citizen type");
                break;
        }
    }

    public void ProduceBuildingCard()
    {

    }

}
public enum CitizenType
{
    GREEN,BLUE,RED
}
