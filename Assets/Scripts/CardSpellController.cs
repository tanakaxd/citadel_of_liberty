using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpellController : CardController
{
    protected override void Start()
    {
        base.Start();
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

}
