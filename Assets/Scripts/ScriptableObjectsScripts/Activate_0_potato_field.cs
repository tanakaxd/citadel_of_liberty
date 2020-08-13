using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "ActivateCardEffect_0_potato_field")]
public class Activate_0_potato_field : ActivateCardEffect
{
    public override IEnumerator Activate(CardController card, PlayerEntity player, BoardEntity board)
    {
        //コスト消費
        //TODO consume anything to activate
        //board.mana.model.greenMana.Value -= card.model.greenToActivate.Value;
        //Debug.Log(card.model.greenToActivate.Value);
        //Debug.Log(board.mana.model.greenMana.Value);
        //食料入手
        GameManager.AddFood(1);//TODO

        Debug.Log("ActivateCardEffect_0_potato_field success");

        yield break;
    }

}