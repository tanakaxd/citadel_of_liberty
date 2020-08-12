using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class ActivateCardEffect : ScriptableObject
{
    public bool Activate(CardController card, PlayerEntity player, BoardEntity board)
    {
        //manaが足りているかチェック
        //もしくはキャンセル処理を可能にする

        if (card.model.greenToActivate.Value > board.mana.model.greenMana.Value)
        {
            Debug.Log("ActivateCardEffect failed: not eonugh mana");
            return false;
        }
        else if(card.model.blueToActivate.Value > board.mana.model.blueMana.Value)
        {
            Debug.Log("ActivateCardEffect failed: not eonugh mana");
            return false;
        }
        else if(card.model.redToActivate.Value > board.mana.model.redMana.Value)
        {
            Debug.Log("ActivateCardEffect failed: not eonugh mana");
            return false;
        }


        if (!DoActivate(card, player, board))
            return false;

        //コスト消費
        board.mana.model.greenMana.Value -= card.model.greenToActivate.Value;
        board.mana.model.blueMana.Value -= card.model.blueToActivate.Value;
        board.mana.model.redMana.Value -= card.model.redToActivate.Value;

        return true;
    }

    public abstract bool DoActivate(CardController card, PlayerEntity player, BoardEntity board);




}
