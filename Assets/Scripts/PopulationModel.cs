using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PopulationModel : MonoBehaviour
{
    public ReactiveCollection<CitizenController> citizens = new ReactiveCollection<CitizenController>();

}
