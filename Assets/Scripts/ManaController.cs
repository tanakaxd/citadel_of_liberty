using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ManaController : MonoBehaviour
{
    public ManaModel model;
    public ManaView view;
    void Start()
    {
        model.greenMana.DistinctUntilChanged()
            .SubscribeToText(view.greenMana);
        model.blueMana.DistinctUntilChanged()
            .SubscribeToText(view.blueMana);
        model.redMana.DistinctUntilChanged()
            .SubscribeToText(view.redMana);
    }


}
