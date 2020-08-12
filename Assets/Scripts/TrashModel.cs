using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class TrashModel : MonoBehaviour
{
    public ReactiveCollection<CardController> cards = new ReactiveCollection<CardController>();
}
