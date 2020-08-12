using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class ManaModel : MonoBehaviour
{
    public IntReactiveProperty greenMana = new IntReactiveProperty(0);
    public IntReactiveProperty blueMana = new IntReactiveProperty(0);
    public IntReactiveProperty redMana = new IntReactiveProperty(0);

}
