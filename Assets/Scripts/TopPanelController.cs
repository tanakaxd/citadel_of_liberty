using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class TopPanelController : MonoBehaviour
{
    public TopPanelFoodView TopPanelFoodView;
    public TopPanelMoneyView TopPanelMoneyView;
    public TopPanelTurnView TopPanelTurnView;

    void Start()
    {
        GameManager.getReactiveFood().DistinctUntilChanged().SubscribeToText(TopPanelFoodView.foodText);
        GameManager.getReactiveMoney().DistinctUntilChanged().SubscribeToText(TopPanelMoneyView.moneyText);
        //GameManager.getReactiveTurn().DistinctUntilChanged().SubscribeToText(TopPanelTurnView.turnText);
    }

}
