using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PlayCardEffect")]
public class PlayCardEffect : ScriptableObject
{
    public int greenMana;
    public int blueMana;
    public int redMana;
    public void GenerateMana(CardController card, BoardEntity board)
    {
        board.mana.model.greenMana.Value += greenMana;
        board.mana.model.blueMana.Value += blueMana;
        board.mana.model.redMana.Value += redMana;
    }

}
