using UniRx;
using UnityEngine;
using static CardData;

public class CardModel : MonoBehaviour
{
    [HideInInspector] public IntReactiveProperty reactiveID;
    [HideInInspector] public StringReactiveProperty cardName;
    [HideInInspector] public StringReactiveProperty codeName;
    [HideInInspector] public CardType type;
    [HideInInspector] public CardCategory category;
    [HideInInspector] public IntReactiveProperty discardsToBuild;
    [HideInInspector] public IntReactiveProperty greenPerTurn;
    [HideInInspector] public IntReactiveProperty bluePerTurn;
    [HideInInspector] public IntReactiveProperty redPerTurn;
    [HideInInspector] public IntReactiveProperty greenToActivate;
    [HideInInspector] public IntReactiveProperty blueToActivate;
    [HideInInspector] public IntReactiveProperty redToActivate;
    [HideInInspector] public IntReactiveProperty anythingToActivate;
    [HideInInspector] public StringReactiveProperty description;

}