using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Activate_10_carpentry")]
public class Activate_10_carpentry : ActivateCardEffect
{
    public override bool DoActivate(CardController card, PlayerEntity player, BoardEntity board)
    {
        

        //建物カード建築
        GameManager.Instance.isBuilding = true;

        Debug.Log("Activate_10_carpentry success");

        return true;
    }

}