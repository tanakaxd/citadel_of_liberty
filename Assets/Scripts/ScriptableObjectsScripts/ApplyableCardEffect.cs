using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ApplyableCardEffect : ScriptableObject, IApplyable
{
    public abstract bool Apply();

}
