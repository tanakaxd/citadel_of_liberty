using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardData : ScriptableObject
{
    //CardModel
    public int ID;
    public string cardName;
    public string codeName;
    public CardType type;
    public CardCategory category;
    public int discardsToBuild;
    public int greenPerTurn;
    public int bluePerTurn;
    public int redPerTurn;
    public int greenToActivate;
    public int blueToActivate;
    public int redToActivate;
    public int anythingToActivate;
    public string description;

    //CardAbility
    public ActivateCardEffect activateCardEffect;
    public GenerateSpellCardEffect generateSpellCardEffect;
    public PlayCardEffect playCardEffect;

    public enum CardType
    {
        BUILDING,CONSUMABLE
    }

    public enum CardCategory
    {
        AGRICULTURE,CONSTRUCTION,GATHERING,STUDY,COMMERCIAL,RELIGION,AGORA,SPELL
    }
}
