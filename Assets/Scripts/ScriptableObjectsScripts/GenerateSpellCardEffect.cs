using UnityEngine;
using System.Collections;
[CreateAssetMenu(menuName = "GenerateSpellCardEffect")]

public class GenerateSpellCardEffect : ScriptableObject
{
    public void GenerateSpell(CardController card, BoardEntity board)
    {
        board.deck.AddSpellCard(card);
    }

}
