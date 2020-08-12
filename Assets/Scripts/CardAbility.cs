using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAbility : MonoBehaviour
{
    public ActivateCardEffect activateCardEffect;
    public GenerateManaCardEffect generateManaCardEffect;

    public void Load(CardData data)
    {
        this.activateCardEffect = data.activateCardEffect;
        this.generateManaCardEffect = data.generateManaCardEffect;
    }

    public bool Activate(CardController card, PlayerEntity player, BoardEntity board)
    {
        return this.activateCardEffect.Activate(card,player,board);
    }

    public void GenerateMana(CardController card, BoardEntity board)
    {
        generateManaCardEffect.GenerateMana(card, board);
    }
}
