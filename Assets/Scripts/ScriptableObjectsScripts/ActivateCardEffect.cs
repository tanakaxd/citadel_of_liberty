using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class ActivateCardEffect : ScriptableObject
{
    public abstract UniTask Activate(CardController card, PlayerEntity player, BoardEntity board);

}
