using UnityEngine;
using UniRx;

public abstract class CardController : MonoBehaviour
{
    public CardModel model;
    public CardView view;
    public CardData data;
    public CardAbility ability;
    public CardDataBase dataBase;
    public CardMovement movement;

    protected BoardEntity board;
    protected PlayerEntity player;

    protected virtual void Awake()
    {
        board = GameObject.Find("BoardEntity").GetComponent<BoardEntity>();
        player = GameObject.Find("PlayerEntity").GetComponent<PlayerEntity>();
    }

    protected virtual void Start()
    {
        model.discardsToBuild.SubscribeToText(view.discardsToBuild);
        model.cardName.SubscribeToText(view.cardName);
        model.description.SubscribeToText(view.description);
    }


    public abstract void LoadData();
    

    public virtual void LoadLogic()
    {
        this.ability.Load(this.data);
    }


    public void Init(int iD)
    {
        //IDからデータベースのデータを入手してロード
        this.data = dataBase.GetData(iD);
        LoadData();
        LoadLogic();
    }

    public void Play()//手札からプレイしたとき,Handから呼び出される
    {
        ability.playCardEffect.GenerateMana(this, board);
    }



}