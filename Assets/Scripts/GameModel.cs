using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class GameModel : MonoBehaviour
{
    public int maxTurn = 10;
    public int initialFood = 3;
    public int initialMoney = 5;
    public int initialDraw = 5;
    public int initialPopulation = 2;
    public int maxPopulation = 20;

    public ReactiveCollection<CitizenController> population = new ReactiveCollection<CitizenController>();

    public IntReactiveProperty currentTurn;
    public IntReactiveProperty food;
    public IntReactiveProperty foodToGrow;
    public IntReactiveProperty money;
    public IntReactiveProperty draws;

    private void Awake()
    {
        currentTurn = new IntReactiveProperty(0);
        food = new IntReactiveProperty(initialFood);
        foodToGrow = new IntReactiveProperty(0);
        money = new IntReactiveProperty(initialMoney);
        draws = new IntReactiveProperty(initialDraw);


    }

    void Start()
    {

    }

}
