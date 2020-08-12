using UnityEngine;
using UniRx;

public class CardController : MonoBehaviour
{
    public CardModel model;
    public CardView view;
    public CardData data;
    public CardAbility ability;
    public CardDataBase dataBase;

    private BoardEntity board;
    private PlayerEntity player;

    private void Awake()
    {
        board = GameObject.Find("BoardEntity").GetComponent<BoardEntity>();
        player = GameObject.Find("PlayerEntity").GetComponent<PlayerEntity>();
    }

    private void Start()
    {
        model.discardsToBuild.SubscribeToText(view.discardsToBuild);
        model.cardName.SubscribeToText(view.cardName);
        model.description.SubscribeToText(view.description);

        //TODO
        this.view.activateButton.OnClickAsObservable().Subscribe(_ => ability.Activate(this,player, board));

        //もともとDataを持っていたら。フィールド初期配置用
        if (data != null)
        {
            LoadData();
            LoadLogic();
        }
    }


    public void LoadData()
    {
        model.reactiveID.Value = data.ID;
        model.cardName.Value = data.cardName;
        model.codeName.Value = data.codeName;
        model.type = data.type;
        model.category = data.category;
        model.discardsToBuild.Value = data.discardsToBuild;
        model.greenPerTurn.Value = data.greenPerTurn;
        model.bluePerTurn.Value = data.bluePerTurn;
        model.redPerTurn.Value = data.redPerTurn;
        model.greenToActivate.Value = data.greenToActivate;
        model.blueToActivate.Value = data.blueToActivate;
        model.redToActivate.Value = data.redToActivate;
        model.anythingToActivate.Value = data.anythingToActivate;
        model.description.Value = data.description;
    }

    public void LoadLogic()
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

    public void GenerateMana(BoardEntity board)
    {
        this.ability.generateManaCardEffect.GenerateMana(this,board);
    }
}