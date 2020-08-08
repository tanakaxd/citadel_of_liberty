using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardData : ScriptableObject
{
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

    public enum CardType
    {
        BUILDING,SPELL
    }

    public enum CardCategory
    {
        AGRICULTURE,CONSTRUCTION,GATHERING,STUDY,COMMERCIAL,RELIGION,AGORA
    }
}
