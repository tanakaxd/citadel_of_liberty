using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class HandModel : MonoBehaviour
{
    public ReactiveCollection<CardController> cards = new ReactiveCollection<CardController>();

}
