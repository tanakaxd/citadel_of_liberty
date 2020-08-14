using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class CardBuildingController : CardController
{
    protected override void Start()
    {
        base.Start();

        //TODO
        this.view.activateButton.OnClickAsObservable().Subscribe(_ => ability.Activate(this, player, board).Forget());

        //もともとDataを持っていたら。フィールド初期配置用
        if (data != null)
        {
            LoadData();
            LoadLogic();
        }
    }

    public override void LoadData()
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

    public void GenerateSpell()
    {
        this.ability.GenerateSpell(this, board);
    }
}
