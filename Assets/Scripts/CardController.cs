using UnityEngine;
using UniRx;

public class CardController : MonoBehaviour
{
    public CardModel model;
    public CardView view;
    private CardData data;
    public CardDataBase dataBase;

    private void Start()
    {
        //model.reactiveID.Subscribe(view.)
        model.discardsToBuild.SubscribeToText(view.discardsToBuild);
        model.cardName.SubscribeToText(view.cardName);
        model.description.SubscribeToText(view.description);

        //もともとDataを持っていたら。フィールド初期配置用
        if (data != null)
        {
            LoadData();
        }
    }

    private void Update()
    {
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

    public void UpdateView()
    {

    }

    public void Init(int iD)
    {
        //IDからデータベースのデータを入手してロード
        this.data = dataBase.GetData(iD);
        LoadData();
        //UpdateView();
    }
}