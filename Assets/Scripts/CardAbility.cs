using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAbility : MonoBehaviour
{
    public ActivateCardEffect activateCardEffect;
    public GenerateSpellCardEffect generateSpellCardEffect;
    public PlayCardEffect playCardEffect;

    public void Load(CardData data)
    {
        this.activateCardEffect = data.activateCardEffect;
        this.generateSpellCardEffect = data.generateSpellCardEffect;
        this.playCardEffect = data.playCardEffect;
    }

    public bool Activate(CardController card, PlayerEntity player, BoardEntity board)
    {
        //manaが足りているかチェック
        //もしくはキャンセル処理を可能にする

        if (card.model.greenToActivate.Value > board.mana.model.greenMana.Value)
        {
            Debug.Log("ActivateCardEffect failed: not eonugh mana");
            return false;
        }
        else if (card.model.blueToActivate.Value > board.mana.model.blueMana.Value)
        {
            Debug.Log("ActivateCardEffect failed: not eonugh mana");
            return false;
        }
        else if (card.model.redToActivate.Value > board.mana.model.redMana.Value)
        {
            Debug.Log("ActivateCardEffect failed: not eonugh mana");
            return false;
        }

        //コスト消費
        board.mana.model.greenMana.Value -= card.model.greenToActivate.Value;
        board.mana.model.blueMana.Value -= card.model.blueToActivate.Value;
        board.mana.model.redMana.Value -= card.model.redToActivate.Value;

        StartCoroutine(this.activateCardEffect.Activate(card, player, board));

        return true;

    }

    public void GenerateSpell(CardController card, BoardEntity board)
    {
        generateSpellCardEffect.GenerateSpell(card, board);
    }
}
