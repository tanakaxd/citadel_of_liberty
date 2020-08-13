using UnityEngine;

[CreateAssetMenu(menuName = "GenerateManaCardEffect")]
public class GenerateManaCardEffect : ScriptableObject
{
    public void GenerateMana(CardController card, BoardEntity board)
    {
        board.mana.model.greenMana.Value += card.model.greenPerTurn.Value;
        board.mana.model.blueMana.Value += card.model.bluePerTurn.Value;
        board.mana.model.redMana.Value += card.model.redPerTurn.Value;
    }

    public void GenerateSpell(CardController card, BoardEntity board)
    {
        board.deck.AddSpellCard(card);
    }
}  